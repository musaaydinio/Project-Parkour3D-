using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunun çözünürlük, tam ekran, ses ve kare hýzý ayarlarýný UI üzerinden yönetiyoruz.
public class SettingMenu : MonoBehaviour
{
    public static int secilenKalite = 2;
   public void TamEkran(bool tamekranmi) 
   {
        // Tam ekran ile pencereli mod arasýndaki geçiþi saðlýyoruz.
        Screen.fullScreen = tamekranmi;
       
   }

    public void GrafikKalite(int indeks)
    {
        // Oyuncunun mevcut tam ekran tercihini bozmadan seçilen indekse göre ekran çözünürlüðünü deðiþtiriyoruz.
        bool mevcutTamEkran = Screen.fullScreen;

        if (indeks == 0)
        {
            Screen.SetResolution(1920, 1080, mevcutTamEkran);
        }
        else if (indeks == 1)
        {
            Screen.SetResolution(1366, 768, mevcutTamEkran);
        }
        else if (indeks == 2)
        {
            Screen.SetResolution(1280, 720, mevcutTamEkran);
        }

        Debug.Log("Çözünürlük baþarýyla þu indekse ayarlandý: " + indeks);
    }

    public void SesSeviye(float sesDegeri)
    {
        // Oyunun genel ses dinleyicisinin þiddetini slider üzerinden gelen deðere göre güncelliyoruz.
        AudioListener.volume = sesDegeri;
    }
    public void FPSDeðeri(int fpsýndex)
    {
        // Kontrol gecikmelerini önlemek için VSync ayarýný kapatýp hedef kare hýzýný oyuncunun seçimine göre sýnýrlandýrýyoruz.
        switch (fpsýndex)
        {
            case 0:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 60;
                break;
            case 1:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = 144;
                break;
            case 2:
                QualitySettings.vSyncCount = 0;
                Application.targetFrameRate = -1;
                break;
        }
        Debug.Log("FPS sýnýrý þu indekse ayarlandý"+fpsýndex);
    }
}
