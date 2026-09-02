using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Oyuncu parkurun sonuna ulaþtýðýnda oyunun bitiþ sürecini, süre hesaplamasýný ve skorlarýn kaydedilmesini yönetiyoruz.
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
        // Bitiþ çizgisi geçildiðinde tetiklenmeyi kontrol ediyoruz. Eðer oyun zaten bittiyse veya çarpan nesne oyuncu deðilse süreci durduruyoruz.
        if (oyunBitti || !other.CompareTag("Player")) return;

        oyunBitti = true;

       
        SureText sayac = FindFirstObjectByType<SureText>();
        if (sayac != null)
        {
            // Zamanlayýcýyý durdurup, oyuncunun parkuru ne kadar sürede tamamladýðý verisini alýyoruz.
            sayac.OyunDurdur();
            float bitisSuresi = sayac.GetGecenZaman();

            // Tamamlanma süresini yerel hafýzadaki liderlik tablosuna gönderiyoruz.
            SkorKaydet(bitisSuresi);

            if (finishPanel != null)
            {
                FinishMenü finishMenu = finishPanel.GetComponent<FinishMenü>();
                if (finishMenu != null)
                {
                    finishMenu.BolumuBitir(bitisSuresi);
                }
            }
            // Kazanma ses efektini ve görsel partikül efektlerini aktif ederek bitiþ anýný kutluyoruz.
            if (bitisEfekti != null)
            {
                bitisEfekti.SetActive(true);
            }

            SoundManager soundManager = FindAnyObjectByType<SoundManager>();
            if (soundManager != null)
            {
                soundManager.WinSesiCal();
            }
            // Oyuncunun efektleri izleyebilmesi için arka planda bir geri sayým baþlatýyoruz.
            StartCoroutine(PaneliGecikmeliAc());
        }
    }
        
     IEnumerator PaneliGecikmeliAc()
    {
        // Belirlediðimiz süre kadar bekleyip ardýndan bitiþ panelini açýyor ve oyun içi zamaný tamamen durduruyoruz.
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

        // Yerel hafýzaya (PlayerPrefs) önceden kaydedilmiþ olan ilk 10 skoru listemize çekiyoruz.
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Skor_" + i))
                skorlar.Add(PlayerPrefs.GetFloat("Skor_" + i));
        }
        // Yeni elde edilen süreyi listeye ekleyip küçükten büyüðe (en kýsa süreden en uzuna) doðru sýralýyoruz.
        skorlar.Add(yeniSure);
        skorlar.Sort();

        // Sýralanmýþ listedeki en iyi ilk 10 skoru tekrar yerel hafýzaya yazdýrýp cihazda kalýcý olarak kaydediyoruz.
        for (int i = 0; i < Mathf.Min(skorlar.Count, 10); i++)
        {
            PlayerPrefs.SetFloat("Skor_" + i, skorlar[i]);
        }
        PlayerPrefs.Save();
    }
}