using UnityEngine;

// Parkur haritasýndaki hareketli engellerin, tuzaklarýn ve Spawner'larýn sadece oyuncu yaklaþtýðýnda
// çalýþmasýný saðlayarak oyunun genel performansýný optimize ediyoruz.
public class DistanceActivator : MonoBehaviour
{
    [Header("Mesafe Ayarý")]
    public float calismaMesafesi = 8f;

    private Transform oyuncu;
    private Animator[] animatorlar;
    private MonoBehaviour[] scriptler;

    private bool calisiyorMu = false;
    private float calismaMesafesiKaresi;

    private void Awake()
    {
        calismaMesafesiKaresi = calismaMesafesi * calismaMesafesi;
    }

    private void Start()
    {
        // Oyun baþladýðýnda oyuncu referansýný buluyor, bileþenleri tarýyor ve donduruyoruz.
        KarakteriBul();
        BilesenleriGuncelle();
        Dondur();
    }

    private void Update()
    {
        if (oyuncu == null)
        {
            KarakteriBul();
            return;
        }

        float mesafeKaresi = (transform.position - oyuncu.position).sqrMagnitude;

        if (mesafeKaresi <= calismaMesafesiKaresi)
        {
            if (!calisiyorMu)
            {
                Calistir();
            }
        }
        else
        {
            if (calisiyorMu)
            {
                Dondur();
            }
        }
    }

    private void KarakteriBul()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            oyuncu = p.transform;
        }
    }

    // Runtime'da sonradan üretilen (Spawn edilen) kütükleri ve yeni scriptleri 
    // anlýk olarak yakalayabilmek için listeyi yenileyen metod.
    private void BilesenleriGuncelle()
    {
        animatorlar = GetComponentsInChildren<Animator>(true);
        scriptler = GetComponentsInChildren<MonoBehaviour>(true);
    }

    private void Calistir()
    {
        calisiyorMu = true;

        // Menziðe girildiðinde sonradan doðan yeni objeleri de kapsamasý için listeyi yeniliyoruz.
        BilesenleriGuncelle();

        foreach (var anim in animatorlar)
        {
            if (anim != null) anim.speed = 1f;
        }

        foreach (var s in scriptler)
        {
            if (s != null && s != this) s.enabled = true;
        }
    }

    private void Dondur()
    {
        calisiyorMu = false;

        // Dondurma anýnda alt objelerdeki tüm yeni parçalarý tarayýp yakalýyoruz.
        BilesenleriGuncelle();

        foreach (var anim in animatorlar)
        {
            if (anim != null) anim.speed = 0f;
        }

        foreach (var s in scriptler)
        {
            if (s != null && s != this) s.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, calismaMesafesi);
    }
}