using UnityEngine;

// Oyuncunun parkura baþladýðý ilk alaný  yönetiyor, süre ve baþlangýç ses tetikleyicilerini buradan uyguluyoruz.
public class StartArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Sadece oyuncu baþlangýç alanýna girdiðinde iþlemleri baþlatýyoruz.
        if (other.CompareTag("Player"))
        {
            // Sahnedeki arayüz sayacýný bulup oyuncunun parkur süresini baþlatýyoruz.
            SureText sayac = FindFirstObjectByType<SureText>();
            if (sayac != null)
            {
                sayac.OyunuBaslat();
            }

            // Merkezi ses yöneticisine ulaþýp oyuna baþlama ses efektini çaldýrýyoruz.
            SoundManager soundManager = FindAnyObjectByType<SoundManager>();
            if (soundManager != null)
            {
                soundManager.BaslangiSesiCal();
            }

            // Baþlangýç çizgisinin görevi bittiði için görünürlüðünü ve fiziksel temasýný kapatýyoruz.
            MeshRenderer mr = GetComponent<MeshRenderer>();
            if (mr != null) mr.enabled = false;

            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            Destroy(gameObject, 3f);
        }
    }
}