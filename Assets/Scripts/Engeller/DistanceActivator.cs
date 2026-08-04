using UnityEngine;

public class MesafeAktiflestirici : MonoBehaviour
{
    [Header("Mesafe Ayarý")]
    public float calismaMesafesi = 8f;

    private Transform oyuncu;
    private Animator[] animatorlar;
    private MonoBehaviour[] scriptler;

    private bool calisiyorMu = false;

    private void Awake()
    {
        // Objedeki ve tüm alt objelerindeki Animator ve Script bileþenlerini yakala
        animatorlar = GetComponentsInChildren<Animator>(true);
        scriptler = GetComponentsInChildren<MonoBehaviour>(true);
    }

    private void Start()
    {
        KarakteriBul();
        Dondur(); // Oyun baþlarken mesafedekileri dondurarak baþlat
    }

    private void Update()
    {
        if (oyuncu == null)
        {
            KarakteriBul();
            return;
        }

        float mesafe = Vector3.Distance(transform.position, oyuncu.position);

        // Karakter mesafeye girdi -> ÇALIÞTIR
        if (mesafe <= calismaMesafesi && !calisiyorMu)
        {
            Calistir();
        }
        // Karakter mesafeden çýktý -> DONDUR
        else if (mesafe > calismaMesafesi && calisiyorMu)
        {
            Dondur();
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

    private void Calistir()
    {
        calisiyorMu = true;

        // 1. Animasyonlarý kaldýðý yerden baþlat (Hýz = 1)
        foreach (var anim in animatorlar)
        {
            if (anim != null) anim.speed = 1f;
        }

        // 2. Scriptleri çalýþtýr (Bu mesafe kontrol scripti hariç)
        foreach (var s in scriptler)
        {
            if (s != null && s != this) s.enabled = true;
        }
    }

    private void Dondur()
    {
        calisiyorMu = false;

       
        foreach (var anim in animatorlar)
        {
            if (anim != null) anim.speed = 0f;
        }

        // 2. Scriptleri devre dýþý býrak (Bu mesafe kontrol scripti hariç)
        foreach (var s in scriptler)
        {
            if (s != null && s != this) s.enabled = false;
        }
    }

    // Sahne görünümünde alaný yeþil çember olarak gösterir
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, calismaMesafesi);
    }
}