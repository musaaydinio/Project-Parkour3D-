using UnityEngine;

// Parkur haritasýndaki hareketli engellerin ve tuzaklarýn sadece oyuncu yaklaþtýðýnda
// çalýþmasýný saðlayarak oyunun genel performansýný optimize ediyoruz.
public class DistanceActivator : MonoBehaviour
{
    [Header("Mesafe Ayarý")]
    public float calismaMesafesi = 8f;

    private Transform oyuncu;
    private Animator[] animatorlar;
    private MonoBehaviour[] scriptler;

    private bool calisiyorMu = false;

    private void Awake()
    {
        // Objenin kendi üzerindeki ve alt objelerindeki tüm animasyon ve script bileþenlerini baþlangýçta tespit edip listeliyoruz.
        animatorlar = GetComponentsInChildren<Animator>(true);
        animatorlar = GetComponentsInChildren<Animator>(true);
        scriptler = GetComponentsInChildren<MonoBehaviour>(true);
    }

    private void Start()
    {
        // Oyun baþladýðýnda oyuncu referansýný buluyor ve gereksiz iþlemci tüketimini önlemek için engelleri donuk halde baþlatýyoruz.
        KarakteriBul();
        Dondur(); 
    }

    private void Update()
    {
        // Oyuncu sahnede henüz yoksa veya referansý koptuysa aramaya devam ediyoruz.    
        if (oyuncu == null)
        {
         KarakteriBul();
         return;
        }
        // Oyuncu ile engel arasýndaki anlýk mesafeyi ölçüyoruz.
        float mesafe = Vector3.Distance(transform.position, oyuncu.position);

        // Oyuncu belirlediðimiz çalýþma menziline girerse sistemi uyandýrýyor, uzaklaþýrsa tekrar donduruyoruz.
        if (mesafe <= calismaMesafesi && !calisiyorMu)
            if (mesafe <= calismaMesafesi && !calisiyorMu)
        {
            Calistir();
        }
        else if (mesafe > calismaMesafesi && calisiyorMu)
        {
            Dondur();
        }
    }

    private void KarakteriBul()
    {
        // Sahnede Player etiketine sahip objeyi bulup hedef referansýmýza eþitliyoruz.
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            oyuncu = p.transform;
        }
    }

    private void Calistir()
    {
        calisiyorMu = true;

        // Oyuncu menzile girdiðinde animasyonlarý normal hýzýna döndürüyoruz.
        foreach (var anim in animatorlar)
        {
            if (anim != null) anim.speed = 1f;
        }

        // Kapatýlmýþ olan tüm mekanik scriptleri tekrar aktif hale getiriyoruz.
        foreach (var s in scriptler)
        {
            if (s != null && s != this) s.enabled = true;
        }
    }

    private void Dondur()
    {
        calisiyorMu = false;

        // Oyuncu menzilden çýktýðýnda iþlemciyi yormamak adýna animasyonlarý tamamen durduruyoruz.
        foreach (var anim in animatorlar)
        {
            if (anim != null) anim.speed = 0f;
        }

        // Mesafe kontrolünü yapan bu script hariç, engel üzerindeki diðer tüm scriptleri kapatýyoruz.
        foreach (var s in scriptler)
        {
            if (s != null && s != this) s.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Unity editörü üzerinde bölüm tasarýmý yaparken mesafe sýnýrýný gözle görebilmek için
        // objenin etrafýna yeþil bir kýlavuz küre çizdiriyoruz.
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, calismaMesafesi);
    }
}