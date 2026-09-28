using System.Collections;
using TMPro;
using UnityEngine;

public class GameStory : MonoBehaviour
{
    [Header("Ortak UI Elemanlarý")]
    public GameObject konusmaBalonuPanel;  
    public TextMeshProUGUI hikayeText;      
    public TextMeshProUGUI devamText;       

    [Header("Daktilo Ayarlarý")]
    public float daktiloHizi = 0.035f;

    [Header("1. BAÞLANGIÇ HÝKAYESÝ")]
    [TextArea(2, 4)]
    public string baslangicMetni1 = "";
    [TextArea(2, 4)]
    public string baslangicMetni2 = "";

    [TextArea(2, 4)]
    public string baslangicMetni3 = "";

    public float loadingGecikmesi = 5.2f;

    [Header("2. BÝTÝÞ HÝKAYESÝ")]
    [TextArea(2, 4)]
    public string bitisMetni = "Harika! Özgürlüðe ulaþmak için sarý alana git ve uçaðý bekle...";

    private bool enterBasildi = false;
    private SoundManager soundManager;
    private Coroutine aktifCoroutine;

    private void Start()
    {
        soundManager = FindFirstObjectByType<SoundManager>();

        if (konusmaBalonuPanel != null) konusmaBalonuPanel.SetActive(false);
        if (devamText != null) devamText.gameObject.SetActive(false);

        StartCoroutine(BaslangicHikayesiniBaslat());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            enterBasildi = true;
        }
    }

    private IEnumerator BaslangicHikayesiniBaslat()
    {
        yield return new WaitForSecondsRealtime(loadingGecikmesi);

        Time.timeScale = 0f;
        OyuncuKontrolunuAyarla(false);

        if (konusmaBalonuPanel != null) konusmaBalonuPanel.SetActive(true);

        yield return StartCoroutine(MetinYazVeBekle(baslangicMetni1));
        yield return StartCoroutine(MetinYazVeBekle(baslangicMetni2));
        yield return StartCoroutine(MetinYazVeBekle(baslangicMetni3));

        if (konusmaBalonuPanel != null) konusmaBalonuPanel.SetActive(false);

        Time.timeScale = 1f;
        OyuncuKontrolunuAyarla(true);

        SureText sayac = FindFirstObjectByType<SureText>();
        if (sayac != null) sayac.OyunuBaslat();
    }

    private IEnumerator MetinYazVeBekle(string metin)
    {
        enterBasildi = false;
        if (devamText != null) devamText.gameObject.SetActive(false);

        hikayeText.text = "";

        // --- KONUÞMA SESÝNÝ BAÞLAT ---
        if (soundManager != null) soundManager.KonusmaSesiBaslat();

        foreach (char harf in metin.ToCharArray())
        {
            // ENTER'a basýlýrsa yazýyý anýnda tamamla
            if (enterBasildi)
            {
                hikayeText.text = metin;
                enterBasildi = false;
                break;
            }

            hikayeText.text += harf;
            yield return new WaitForSecondsRealtime(daktiloHizi);
        }

        // --- YAZI BÝTTÝ, KONUÞMA SESÝNÝ DURDUR ---
        if (soundManager != null) soundManager.KonusmaSesiDurdur();

        enterBasildi = false;
        if (devamText != null)
        {
            devamText.text = "Geçmek için ENTER'a bas ";
            devamText.gameObject.SetActive(true);
        }

        while (!enterBasildi)
        {
            yield return null;
        }

        enterBasildi = false;
        if (devamText != null) devamText.gameObject.SetActive(false);
    }

    public void FinishHikayesiGoster()
    {
        if (aktifCoroutine != null) StopCoroutine(aktifCoroutine);
        if (konusmaBalonuPanel != null) konusmaBalonuPanel.SetActive(true);

        aktifCoroutine = StartCoroutine(MetinYazVeBekle(bitisMetni));
    }

    public void HikayeGizle()
    {
        if (aktifCoroutine != null) StopCoroutine(aktifCoroutine);
        if (soundManager != null) soundManager.KonusmaSesiDurdur();
        if (konusmaBalonuPanel != null) konusmaBalonuPanel.SetActive(false);
        if (devamText != null) devamText.gameObject.SetActive(false);
    }

    private void OyuncuKontrolunuAyarla(bool aktifMi)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = aktifMi;

        MonoBehaviour[] tumScriptler = player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in tumScriptler)
        {
            if (script != this)
            {
                script.enabled = aktifMi;
            }
        }
    }
}