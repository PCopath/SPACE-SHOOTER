using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private MarketController marketController;

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text gameOverText;
    public Text restartText;
    public Text scoreText;
    public Text waveText; // Dalga sayısını göstermek için yeni bir Text

    private int score;
    private int waveNumber; // Dalga sayısını takip etmek için değişken
    private bool gameOver;
    private bool restart;
    private int playerCurrency;

    public Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        marketController = FindObjectOfType<MarketController>();
        
        gameOver = false;
        restart = false;

        gameOverText.text = "";
        restartText.text = "";
        waveText.text = ""; // Başlangıçta boş göster

        score = 0;
        waveNumber = 0; // İlk dalga başlangıç
        WriteScore();

        // Daha önce kaydedilmiş para miktarını yükle
        playerCurrency = PlayerPrefs.GetInt("PlayerCurrency", 0);
        UpdateCurrencyText(); // Para Text'ini güncelle
        Debug.Log("Yüklü Para: " + playerCurrency);

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            waveNumber++; // Dalga numarasını artır
            waveText.text = "Wave: " + waveNumber; // Ekrana dalga numarasını yaz

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            // Zorluğu artır
            hazardCount += 2;                // Her dalga için daha fazla tehlike
            spawnWait = Mathf.Max(0.3f, spawnWait - 0.05f); // Spawn süresini azalt
            waveWait = Mathf.Max(2f, waveWait - 0.2f);      // Dalga arası beklemeyi azalt
        }
    }

    public void AddScore()
    {
        if (marketController.shotType == 2)
        {
            score += 20; // Her çağrıda 10 puan ekle
            WriteScore();
            //return;
        }
        else
        {
            score += 10; // Her çağrıda 10 puan ekle
            WriteScore();
        }
    }

    void WriteScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOver = true; // Game over durumunu true yap
        gameOverText.text = "Game Over!"; // Game over mesajını göster
        restartText.text = "Press 'R' to Restart"; // Restart mesajını göster
        restart = true; // Restart durumunu aktif et

        playerCurrency += score;
        PlayerPrefs.SetInt("PlayerCurrency", playerCurrency);
        PlayerPrefs.Save();

        UpdateCurrencyText(); // Para Text'ini güncelle
        Debug.Log("Oyun bitti. Yeni Para Miktarı: " + playerCurrency);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCurrency()
    {
        return playerCurrency;
    }

    public void DecreaseScore(int amount)
    {
        playerCurrency -= amount; // Parayı azalt
        PlayerPrefs.SetInt("PlayerCurrency", playerCurrency); // Güncellenen parayı kaydet
        PlayerPrefs.Save();
        UpdateCurrencyText(); // Para Text'ini güncelle
    }

    private void UpdateCurrencyText()
    {
        currencyText.text = "Currency: " + playerCurrency.ToString();
    }

    public void SaveSelectedShip(int spaceshipIndex)
    {
        PlayerPrefs.SetInt("SelectedShip", spaceshipIndex);
        PlayerPrefs.Save();
    }
}
