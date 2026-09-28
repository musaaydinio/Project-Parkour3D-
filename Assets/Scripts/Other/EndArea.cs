using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndArea : MonoBehaviour
{
    [Header("UI ve Bitiþ Elemanlarý")]
    public GameObject finishPanel;          // Bitiþ Yeniden Baþla / Ana Menü Paneli
    public GameObject bitisEfekti;          // Konfeti / Partikül efekti

    [Header("Sarý Alan ve Sinematik Video")]
    public GameObject sariAlanObject;       // Zirvedeki sarý obje (Trigger)
    public GameObject videoRawImageObj;     // Videonun basýldýðý RawImage / Video Paneli
    public VideoPlayer finalVideoPlayer;    // Video Player Bileþeni

    private bool finishCizgisiGecildi = false;
    private bool videoBasladi = false;

    private void Start()
    {
        if (videoRawImageObj != null) videoRawImageObj.SetActive(false);
        if (sariAlanObject != null) sariAlanObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // 1. AÞAMA: Finiþ Çizgisine Ýlk Temas
        if (!finishCizgisiGecildi)
        {
            finishCizgisiGecildi = true;
            FinisCizgisiniTetikle();
        }
    }

    private void FinisCizgisiniTetikle()
    {
        // 1. Sayacý durdur ve skoru kaydet
        SureText sayac = FindFirstObjectByType<SureText>();
        if (sayac != null)
        {
            sayac.OyunDurdur();
            float bitisSuresi = sayac.GetGecenZaman();
            SkorKaydet(bitisSuresi);

            if (finishPanel != null)
            {
                FinishMenü finishMenu = finishPanel.GetComponent<FinishMenü>();
                if (finishMenu != null) finishMenu.BolumuBitir(bitisSuresi);
            }
        }

        // 2. Efekt ve Kazanma Sesini Çalýþtýr
        if (bitisEfekti != null) bitisEfekti.SetActive(true);

        SoundManager soundManager = FindAnyObjectByType<SoundManager>();
        if (soundManager != null) soundManager.WinSesiCal();

        // 3. Sarý Alaný Aç (Oyuncu serbestçe koþmaya ve hareket etmeye devam eder!)
        if (sariAlanObject != null) sariAlanObject.SetActive(true);

        // 4. GameStory Script'indeki Bitiþ Daktilo Yazýsýný Çaðýr
        GameStory hikaye = FindFirstObjectByType<GameStory>();
        if (hikaye != null)
        {
            hikaye.FinishHikayesiGoster();
        }
    }

    // 2. AÞAMA: Sarý Alana (Kaçýþ Noktasýna) Girildiðinde Çalýþýr
    public void SariAlanaGirildi(GameObject playerObj)
    {
        if (videoBasladi) return;
        videoBasladi = true;

        // Ekranda açýk kalan konuþma balonunu/daktilo yazýsýný kapat
        GameStory hikaye = FindFirstObjectByType<GameStory>();
        if (hikaye != null)
        {
            hikaye.HikayeGizle();
        }

        // HAREKET VE GÖRSELLERÝ SARI ALANDA KAPATIYORUZ (Kamera AÇIK kalýr)
        if (playerObj != null)
        {
            Rigidbody rb = playerObj.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = true;

            CharacterController cc = playerObj.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            MonoBehaviour[] tumScriptler = playerObj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in tumScriptler)
            {
                if (script != this)
                {
                    script.enabled = false;
                }
            }

            Renderer[] renderers = playerObj.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                if (r is MeshRenderer || r is SkinnedMeshRenderer)
                {
                    r.enabled = false;
                }
            }
        }

        // Videoyu baþlat ve ekraný aç
        if (videoRawImageObj != null && finalVideoPlayer != null)
        {
            videoRawImageObj.SetActive(true);
            finalVideoPlayer.playOnAwake = false;
            finalVideoPlayer.loopPointReached += OnVideoBitti;
            finalVideoPlayer.Play();
        }
        else
        {
            OnVideoBitti(finalVideoPlayer);
        }
    }

    private void OnVideoBitti(VideoPlayer vp)
    {
        if (finalVideoPlayer != null)
        {
            finalVideoPlayer.loopPointReached -= OnVideoBitti;
        }

        if (videoRawImageObj != null) videoRawImageObj.SetActive(false);

        if (finishPanel != null) finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void SkorKaydet(float yeniSure)
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