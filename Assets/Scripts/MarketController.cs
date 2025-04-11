using UnityEngine;

public class MarketController : MonoBehaviour
{
    public GameObject marketPanel;
    private GameController gameController;
    public int shotType = 1;
    private int shipType = 1;

    public GameObject shotPrefab;
    public GameObject[] typePrefabs; 
    public GameObject[] spaceshipPrefabs; // Farklı uzay gemisi prefabları için bir dizi
    public Transform playerSpawnPoint;   // Yeni prefabın konumu

    private GameObject currentPlayer;    // Şu anda kullanılan oyuncu objesi



    private bool isMarketOpen = false;

    // Market UI'sini aç/kapat
    public void ToggleMarket()
    {
        isMarketOpen = !isMarketOpen;

        if (isMarketOpen)
        {
            OpenMarket();
        }
        else
        {
            CloseMarket();
        }
    }

    void OpenMarket()
    {
        marketPanel.SetActive(true); // Market UI'sini aktif et
        Time.timeScale = 0; // Oyunu durdur
        Debug.Log("Market açıldı, oyun durduruldu.");
    }

    void CloseMarket()
    {
        marketPanel.SetActive(false); // Market UI'sini kapat
        Time.timeScale = 1; // Oyunu devam ettir
        Debug.Log("Market kapatıldı, oyun devam ediyor.");
    }





    void Start()
    {
        marketPanel.SetActive(false);

        // GameController referansını bul
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController bulunamadı!");
        }

        // Mevcut oyuncu gemisini sahnede bul ve referans olarak al
        currentPlayer = GameObject.FindWithTag("Player");
    }

   
    public void BuyItem(int price, int spaceshipIndex)
    {
        int currentCurrency = gameController.GetCurrency();

        if (currentCurrency >= price)
        {
            gameController.DecreaseScore(price); // Parayı düşür

            // Satın alınan gemiyi kaydet
            gameController.SaveSelectedShip(spaceshipIndex);

            // Satın alınan gemiyi sahnede değiştir
            ChangeSpaceship();

            Debug.Log("Yeni uzay gemisi satın alındı!");
        }
        else
        {
            Debug.Log("Yetersiz bakiye!");
        }
    }

    public void BuySpaceship1()
    {
        shipType = 2;
        BuyItem(300, 0); // 50 para ve 0. indexteki gemi
    }

    public void BuyShotType()
    {
        shotType = 2;
        BuyItem(200, 1); // 100 para ve 1. indexteki gemi
    }

  

    private void ChangeSpaceship()
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }



        if (shotType == 2 && shipType == 1)
        {
            currentPlayer = Instantiate(typePrefabs[0], playerSpawnPoint.position, playerSpawnPoint.rotation);
            Debug.Log("ill if girdim");




        }
        else if (shotType == 2 && shipType == 2)
        {
            currentPlayer = Instantiate(typePrefabs[1], playerSpawnPoint.position, playerSpawnPoint.rotation);
            Debug.Log("else if girdim");


        }
        else if (shotType == 1  && shipType == 2)
        {
            currentPlayer = Instantiate(typePrefabs[2], playerSpawnPoint.position, playerSpawnPoint.rotation);
            Debug.Log("else girdim");


        }


        //if (spaceshipIndex < 0 || spaceshipIndex >= spaceshipPrefabs.Length)
        //{
        //    Debug.LogError("Geçersiz uzay gemisi indexi!");
        //    return;
        //}

        // Eski gemiyi yok et

        // Yeni gemiyi oluştur
        //currentPlayer.tag = "Player"; // Yeni gemiye Player tag'i ekle
    }
}

