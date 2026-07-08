using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public static int secilenKalite = 2;
   public void TamEkran(bool tamekranmi) 
   {
        Screen.fullScreen = tamekranmi;         
   }

    public void GrafikKalite(int indeks)
    {
       
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
        AudioListener.volume = sesDegeri;
    }
}
