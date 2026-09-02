using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunun ana menüsündeki arayüz geçişlerini, oyuna başlama ve çıkış işlemlerini yönetiyoruz.
public class MaınMenu : MonoBehaviour
{
    public GameObject ayarlarPaneli;
    public GameObject skorPaneli;
    public GameObject klavyePanel;

    private void Start()
    {
        // Ana menü yüklendiğinde ekranın temiz görünmesi için alt panelleri kapalı konuma getiriyoruz.
        ayarlarPaneli.SetActive(false);
        skorPaneli.SetActive(false);
    }
    public void OyunaBasla()
    {
        SceneManager.LoadScene(1);
    }
    public void AyarlarAc()
    {
        ayarlarPaneli.SetActive(true);
    }
    public void AyarlarKapat()
    {
        ayarlarPaneli.SetActive(false);
    }
    public void SkorAc()
    {
        skorPaneli.SetActive(true);
    }
    public void SkorKapat()
    {
        skorPaneli.SetActive(false) ;
    }
    public void KlavyeAc()
    {
        klavyePanel.SetActive(true);
    }
    public void KlavyeKapat()
    {
        klavyePanel.SetActive(false) ;
    }
    public void OyundanCıkıs()
    {
        Application.Quit();
        Debug.Log("Oyundan çıkış yapıldı.");
    }
}
