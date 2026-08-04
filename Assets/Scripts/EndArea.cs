using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EndArea : MonoBehaviour
{
    [Header("UI ve Zamanlama")]
    public GameObject finishPanel;
    public float gecikmeSuresi = 5f;

    [Header("Efect ve Ses")]
    public GameObject bitisEfekti;
    

    private bool oyunBitti=false;


    private void OnTriggerEnter(Collider other)
    {
        if (oyunBitti || !other.CompareTag("Player")) return;

        oyunBitti = true;

       
        SureText sayac = FindFirstObjectByType<SureText>();
        if (sayac != null)
        {
            sayac.OyunDurdur();
            float bitisSuresi = sayac.GetGecenZaman();

            SkorKaydet(bitisSuresi);

            if (finishPanel != null)
            {
                FinishMenü finishMenu = finishPanel.GetComponent<FinishMenü>();
                if (finishMenu != null)
                {
                    finishMenu.BolumuBitir(bitisSuresi);
                }
            }
            if (bitisEfekti != null)
            {
                bitisEfekti.SetActive(true);
            }

            SoundManager soundManager = FindAnyObjectByType<SoundManager>();
            if (soundManager != null)
            {
                soundManager.WinSesiCal();
            }

            StartCoroutine(PaneliGecikmeliAc());
        }
    }
        
     IEnumerator PaneliGecikmeliAc()
    {
        yield return new WaitForSeconds(gecikmeSuresi);

        if (finishPanel != null)
        {
            finishPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    void SkorKaydet(float yeniSure)
    {
        List<float> skorlar = new List<float>();
      
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Skor_" + i))
                skorlar.Add(PlayerPrefs.GetFloat("Skor_" + i));
        }
        
        skorlar.Add(yeniSure);
        skorlar.Sort();
        
        for (int i = 0; i < Mathf.Min(skorlar.Count, 10); i++)
        {
            PlayerPrefs.SetFloat("Skor_" + i, skorlar[i]);
        }
        PlayerPrefs.Save();
    }
}