using System.Collections;
using TMPro;
using UnityEngine;

public class SureText : MonoBehaviour
{
    [Header("UI Elemanlarý")]
    public TextMeshProUGUI sayacText;
    public GameObject gameOverPanel;

    [Header("Süre Ayarý (Saniye)")]
    [Tooltip("Normal sahnede 600 (10 dk), Hard sahnede 300 (5 dk) yazýn.")]
    public float baslangicSuresi = 600f;

    private float kalanSure;
    private bool oyunBasladi = false;
    private int sonCalinanSaniye = -1;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindFirstObjectByType<SoundManager>();
        kalanSure = baslangicSuresi;
        if (sayacText != null) sayacText.color = Color.white; // Baþlangýçta yazý beyaz
        EkranýGuncelle();
    }

    public void OyunuBaslat()
    {
        kalanSure = baslangicSuresi;
        oyunBasladi = true;
        Time.timeScale = 1f;
        if (sayacText != null) sayacText.color = Color.white;
        sonCalinanSaniye = -1;
    }

    private void Update()
    {
        if (!oyunBasladi) return;

        if (kalanSure > 0f)
        {
            kalanSure -= Time.deltaTime;

            // --- SON 10 SANÝYE: SADECE RAKAMLARI KIRMIZI-BEYAZ YANIP SÖNDÜR ---
            if (kalanSure <= 10f)
            {
                if (sayacText != null)
                {
                    // PingPong ile zaman faktörünü kullanarak sadece saat yazýsýnýn rengini deðiþtiriyoruz
                    float t = Mathf.PingPong(Time.time * 8f, 1f);
                    sayacText.color = Color.Lerp(Color.white, Color.red, t);
                }

                // Her saniye baþý SoundManager'dan gerilim týk-tak sesini tetikle
                int mevcutSaniye = Mathf.CeilToInt(kalanSure);
                if (mevcutSaniye != sonCalinanSaniye && mevcutSaniye > 0)
                {
                    sonCalinanSaniye = mevcutSaniye;
                    if (soundManager != null) soundManager.GerilimSesiCal();
                }
            }

            EkranýGuncelle();
        }
        else
        {
            kalanSure = 0f;
            EkranýGuncelle();
            SureBitti();
        }
    }

    private void EkranýGuncelle()
    {
        if (sayacText == null) return;

        int dakika = Mathf.FloorToInt(kalanSure / 60f);
        int saniye = Mathf.FloorToInt(kalanSure % 60f);

        sayacText.text = string.Format("{0:00}:{1:00}", dakika, saniye);
    }

    private void SureBitti()
    {
        oyunBasladi = false;

        // Süre bittiðinde saat yazýsýný sabit kýrmýzý yap
        if (sayacText != null) sayacText.color = Color.red;

        // Arka plan müziðini kesip Game Over efektini çalýþtýr
        if (soundManager != null)
        {
            soundManager.GameOverSesiCal();
        }

        // Karakterin hareketlerini ve fiziki girdilerini dondur
        OyuncuHareketiniDondur();

        // Game Over panelini aç ve zamaný durdur
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    private void OyuncuHareketiniDondur()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        MonoBehaviour[] tumScriptler = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in tumScriptler)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }
    }

    public void OyunDurdur()
    {
        oyunBasladi = false;
    }

    public float GetGecenZaman()
    {
        return baslangicSuresi - kalanSure;
    }
}