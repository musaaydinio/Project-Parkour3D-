using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Oyun sýrasýnda ESC tuþuna basýldýðýnda zamaný durdurarak açýlan duraklatma (Pause) menüsünü yönetiyoruz.
public class PausePanel : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject ayarlarMenu;

    private bool oyunDurdumu = false;

    private void Update()
    {
        // Oyuncu ESC tuþuna bastýðýnda mevcut duruma göre oyunu ya durduruyor ya da devam ettiriyoruz.
        if (Input.GetKeyUp(KeyCode.Escape))
            if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (oyunDurdumu == true)
            {
                OyunaDevamEt();
            }
            else
            {
                OyunuDurdur();
            }
        }
    }
    public void OyunuDurdur()
    {
        pauseMenu.SetActive(true);
        ayarlarMenu.SetActive(false);

        // Oyun içi zamaný tamamen durdurarak fiziksel hareketlerin ve animasyonlarýn akmasýný engelliyoruz.
        Time.timeScale = 0f;
        oyunDurdumu = true;

        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
    }
    public void OyunaDevamEt()
    {
        pauseMenu.SetActive(false);
        ayarlarMenu.SetActive(false);
        // Zamaný normal akýþýna döndürüyoruz.
        Time.timeScale = 1f;
        oyunDurdumu=false;

        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void YenidenBaslat()
    {
        // Oyuncunun hatasýz bir þekilde baþtan baþlayabilmesi için zamaný normale döndürüp mevcut sahneyi baþtan yüklüyoruz.
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AnaMenuDon()
    {
        Time.timeScale= 1f;
        SceneManager.LoadScene(0);
    }
    public void AyarlarýAc()
    {
        pauseMenu.SetActive(false);
        ayarlarMenu.SetActive(true);
    }
    public void AyarlarýKapa()
    {
        ayarlarMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}
