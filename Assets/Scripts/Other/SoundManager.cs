using UnityEngine;

// Parkur oyunumuzdaki tüm arka plan müziklerini ve anlýk ses efektlerini
// (zýplama, hasar, ölüm, bitiþ vb.) merkezi tek bir noktadan yönetiyoruz.
public class SoundManager : MonoBehaviour
{
    [Header("Ses Kaynaklarý")]    
    public AudioSource muzikKaynagi;  
    public AudioSource efektKaynagi;

    [Header("Müzikler")]   
    public AudioClip oyunMuzigi;
    public AudioClip winSesi;

    [Header("Ses Efektleri")]
    public AudioClip hasarSesi;
    public AudioClip olumSesi;   
    public AudioClip ziplamaSesi;
    public AudioClip baslangicsesi;
    public AudioClip checkpoint;

    private void Start()
    {
        OyunMuzigiBaslat();
    }  

    public void OyunMuzigiBaslat()
    {
        muzikKaynagi.clip=oyunMuzigi;
        muzikKaynagi .Play();
    }

    public void HasarSesiCal()
    {
        efektKaynagi.PlayOneShot(hasarSesi);
    }
    public void ZiplamaSesiCal()
    {
        efektKaynagi.PlayOneShot(ziplamaSesi);
    }
    public void OlumSesical()
    {
        muzikKaynagi.Stop();
        efektKaynagi.PlayOneShot(olumSesi);
    }
    public void WinSesiCal()
    {
        muzikKaynagi.Stop();
        muzikKaynagi.clip = winSesi;
        muzikKaynagi.loop = true;
        muzikKaynagi .Play();
    }
    public void BaslangiSesiCal()
    {        
        efektKaynagi.PlayOneShot(baslangicsesi);
        muzikKaynagi.volume = 0f;
        Invoke("OyunMuzigiGeriAc", 1.5f);
    }
    public void CheckPointCal()
    {
        efektKaynagi.PlayOneShot(checkpoint);
    }
    void OyunMuzigiGeriAc()
    {
        muzikKaynagi.volume = 1f;
    }
}
