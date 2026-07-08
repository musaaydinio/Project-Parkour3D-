using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject ayarlarMenu;

    private bool oyunDurdumu = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetMouseButtonDown(1))
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
        Time.timeScale = 0f;
        oyunDurdumu = true;

        Cursor.visible = true; // Fare imlecini görünür yap
        Cursor.lockState = CursorLockMode.None;
    }
    public void OyunaDevamEt()
    {
        pauseMenu.SetActive(false);
        ayarlarMenu.SetActive(false);
        Time.timeScale = 1f;
        oyunDurdumu=false;

        Cursor.visible = false; // Fare imlecini gizle
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void YenidenBaslat()
    {
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
