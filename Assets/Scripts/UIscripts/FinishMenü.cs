using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenü : MonoBehaviour
{
    public GameObject finishpanel;
    public TextMeshProUGUI mevcutskor;

    public void BolumuBitir(float bitisSuresi)
    {
        // Bitiş paneli açıldığında arka planda oyunun akmasını veya karakterin düşmesini engellemek için zamanı tamamen durduruyoruz.
        if (finishpanel != null) finishpanel.SetActive(true);
        Time.timeScale = 0f;

        // Toplam saniye olarak gelen bitiş süresini matematiksel işlemlerle dakika ve saniye formatına çevirip metin alanına yazdırıyoruz.
        int dakika = Mathf.FloorToInt(bitisSuresi / 60f);
        int saniye = Mathf.FloorToInt(bitisSuresi % 60F);
        mevcutskor.text = string.Format("Süreniz: {0:00}:{1:00}", dakika, saniye);

    }  
}
 

