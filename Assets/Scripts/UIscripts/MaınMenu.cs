using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunun ana menüsündeki arayüz geçişlerini, oyuna başlama ve çıkış işlemlerini yönetiyoruz.
public class MaınMenu : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject ayarlarPaneli;
    public GameObject skorPaneli;
    public GameObject klavyePanel;

    private void Start()
    {
        // Ana menü yüklendiğinde ekranın temiz görünmesi için alt panelleri kapalı konuma getiriyoruz.
        if (ayarlarPaneli != null) ayarlarPaneli.SetActive(false);
        if (skorPaneli != null) skorPaneli.SetActive(false);
        if (klavyePanel != null) klavyePanel.SetActive(false);
    }

    // Normal Mod Butonu (Sahne İndeksi: 1)
    public void NormalModBasla()
    {
        SceneManager.LoadScene(1);
    }

    // Zor Mod Butonu (Sahne İndeksi: 2)
    public void ZorModBasla()
    {
        SceneManager.LoadScene(2); // Veya tırnak içinde sahne adı: SceneManager.LoadScene("ZorModScene");
    }

    public void AyarlarAc()
    {
        if (ayarlarPaneli != null) ayarlarPaneli.SetActive(true);
    }

    public void AyarlarKapat()
    {
        if (ayarlarPaneli != null) ayarlarPaneli.SetActive(false);
    }

    public void SkorAc()
    {
        if (skorPaneli != null) skorPaneli.SetActive(true);
    }

    public void SkorKapat()
    {
        if (skorPaneli != null) skorPaneli.SetActive(false);
    }

    public void KlavyeAc()
    {
        if (klavyePanel != null) klavyePanel.SetActive(true);
    }

    public void KlavyeKapat()
    {
        if (klavyePanel != null) klavyePanel.SetActive(false);
    }

    public void OyundanCıkıs()
    {
        Application.Quit();
        Debug.Log("Oyundan çıkış yapıldı.");
    }
}