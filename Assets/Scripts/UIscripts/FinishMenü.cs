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
        if (finishpanel != null) finishpanel.SetActive(true);
        Time.timeScale = 0f;

        int dakika = Mathf.FloorToInt(bitisSuresi / 60f);
        int saniye = Mathf.FloorToInt(bitisSuresi % 60F);
        mevcutskor.text = string.Format("Süreniz: {0:00}:{1:00}", dakika, saniye);

    }  
}
 

