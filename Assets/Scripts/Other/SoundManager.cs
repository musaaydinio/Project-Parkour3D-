using UnityEngine;

// Oyunun tüm seslerini tek bir merkezden yöneten,
// kanallarýný Awake() içinde kendisi oluþturan SoundManager.
public class SoundManager : MonoBehaviour
{
    [Header("Müzik")]
    public AudioClip oyunMuzigi;

    [Header("Ses Efektleri")]
    public AudioClip hasarSesi;
    public AudioClip olumSesi;
    public AudioClip ziplamaSesi;
    public AudioClip baslangicsesi;
    public AudioClip checkpoint;
    public AudioClip winSesi;
    public AudioClip gerilimSesi;
    public AudioClip gameOverSesi;
    public AudioClip konusmaSesi;

    // Kodun kendi yönettiði gizli kanallar (Inspector'da atama yapman gerekmez)
    private AudioSource muzikKaynagi;
    private AudioSource efektKaynagi;
    private AudioSource konusmaKaynagi;

    private void Awake()
    {
        // 1. Müzik Kanalý
        muzikKaynagi = gameObject.AddComponent<AudioSource>();
        muzikKaynagi.loop = true;

        // 2. Anlýk Efektler Kanalý (Zýplama, Bitiþ, Hasar)
        efektKaynagi = gameObject.AddComponent<AudioSource>();

        // 3. Konuþma Kanalý ("Bla bla" diyalog sesi)
        konusmaKaynagi = gameObject.AddComponent<AudioSource>();
        konusmaKaynagi.loop = true;
    }

    private void Start()
    {
        OyunMuzigiBaslat();
    }

    public void OyunMuzigiBaslat()
    {
        if (oyunMuzigi != null)
        {
            muzikKaynagi.clip = oyunMuzigi;
            muzikKaynagi.Play();
        }
    }

    public void HasarSesiCal() => efektKaynagi.PlayOneShot(hasarSesi);
    public void ZiplamaSesiCal() => efektKaynagi.PlayOneShot(ziplamaSesi);
    public void CheckPointCal() => efektKaynagi.PlayOneShot(checkpoint);
    public void GerilimSesiCal() { if (gerilimSesi != null) efektKaynagi.PlayOneShot(gerilimSesi); }

    public void OlumSesical()
    {
        muzikKaynagi.Stop();
        konusmaKaynagi.Stop();
        efektKaynagi.PlayOneShot(olumSesi);
    }

    // Finiþ Çizgisinde Çalýþan Metod
    public void WinSesiCal()
    {
        muzikKaynagi.Stop();        // Arka plan müziðini kapat
        konusmaKaynagi.Stop();     // Varsa devam eden konuþma sesini kapat

        if (winSesi != null)
        {
            efektKaynagi.PlayOneShot(winSesi); // Finiþ sesini baðýmsýz çal (Asla kesilmez)
        }
    }

    public void BaslangiSesiCal()
    {
        efektKaynagi.PlayOneShot(baslangicsesi);
        muzikKaynagi.volume = 0f;
        Invoke("OyunMuzigiGeriAc", 1.5f);
    }

    public void GameOverSesiCal()
    {
        if (muzikKaynagi != null) muzikKaynagi.Stop();
        if (konusmaKaynagi != null) konusmaKaynagi.Stop();
        if (efektKaynagi != null)
        {
            efektKaynagi.Stop();
            if (gameOverSesi != null) efektKaynagi.PlayOneShot(gameOverSesi);
        }
    }

    // GameStory Diyaloglarý Tarafýndan Çaðrýlýr
    public void KonusmaSesiBaslat()
    {
        if (konusmaSesi != null)
        {
            konusmaKaynagi.clip = konusmaSesi;
            konusmaKaynagi.Play();
        }
    }

    public void KonusmaSesiDurdur()
    {
        if (konusmaKaynagi != null)
        {
            konusmaKaynagi.Stop();
        }
    }

    private void OyunMuzigiGeriAc()
    {
        if (muzikKaynagi != null) muzikKaynagi.volume = 1f;
    }
}