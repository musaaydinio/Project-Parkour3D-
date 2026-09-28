using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [Header("UI Elemanlarý")]
    public GameObject loadingPanel;
    public TextMeshProUGUI yuzdeText;    
    public Image dolumBarImage;       
    [Header("Yükleme Ayarlarý")]
    public float beklemeSuresi = 5f;     
    [Header("Oyuncu Kilidi")]
    public GameObject playerObj;

    private void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindWithTag("Player");
        }

        // Sahne ilk açýldýðýnda giriþ yüklemesi çalýþýr
        StartCoroutine(SahneyeGirisEfekti());
    }

    private IEnumerator SahneyeGirisEfekti()
    {
        loadingPanel.SetActive(true);
        OyuncuKontrolunuAyarla(false);

        yield return StartCoroutine(YuklemeBariniDoldur());

        loadingPanel.SetActive(false);
        OyuncuKontrolunuAyarla(true);
    }

    public void AnaMenuyeDon()
    {
        StartCoroutine(SahnedenCikisEfekti("MaýnMenu"));
    }

    // Sahne adýný dýþarýdan vermek istersen:
    public void SahneYukle(string sahneAdi)
    {
        StartCoroutine(SahnedenCikisEfekti(sahneAdi));
    }

    private IEnumerator SahnedenCikisEfekti(string sahneAdi)
    {
        Time.timeScale = 1f; 

        loadingPanel.SetActive(true);
        OyuncuKontrolunuAyarla(false);

        // 5 saniyelik yükleme barý çalýþýr
        yield return StartCoroutine(YuklemeBariniDoldur());

        // Süre bitince sahneye geçer
        SceneManager.LoadScene(sahneAdi);
    }

    // Ortak Bar Doldurma Metodu
    private IEnumerator YuklemeBariniDoldur()
    {
        if (yuzdeText != null) yuzdeText.text = "%0";
        if (dolumBarImage != null) dolumBarImage.fillAmount = 0f;

        float gecenSure = 0f;

        while (gecenSure < beklemeSuresi)
        {
            gecenSure += Time.deltaTime;
            float oran = Mathf.Clamp01(gecenSure / beklemeSuresi);

            if (yuzdeText != null)
                yuzdeText.text = "%" + Mathf.RoundToInt(oran * 100f).ToString();

            if (dolumBarImage != null)
                dolumBarImage.fillAmount = oran;

            yield return null;
        }

        if (yuzdeText != null) yuzdeText.text = "%100";
        if (dolumBarImage != null) dolumBarImage.fillAmount = 1f;

        yield return new WaitForSeconds(0.3f);
    }

    private void OyuncuKontrolunuAyarla(bool aktifMi)
    {
        if (playerObj == null) return;

        CharacterController cc = playerObj.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = aktifMi;

        Rigidbody rb = playerObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (!aktifMi)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            rb.isKinematic = !aktifMi;
        }

        MonoBehaviour[] tumScriptler = playerObj.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in tumScriptler)
        {
            if (script != this)
            {
                script.enabled = aktifMi;
            }
        }
    }
}