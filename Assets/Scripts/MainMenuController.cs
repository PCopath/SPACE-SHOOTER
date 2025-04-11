using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Oyunu kapat
        Debug.Log("Oyun kapatıldı!");
        Application.Quit();
    }
}
