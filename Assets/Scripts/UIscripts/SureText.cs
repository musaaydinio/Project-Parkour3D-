using TMPro;
using UnityEngine;

// Parkur boyunca geçen süreyi hesaplayýp ekrandaki kronometre arayüzüne anlýk olarak yansýtýyoruz.
public class SureText : MonoBehaviour
{
    public TextMeshProUGUI oyunSayac;

    private float gecenZaman = 0f;
    private bool devamEdiyor=false;

    private void Update()
    {
        // Zamanlayýcý aktifse her karede geçen süreyi toplayýp dakika ve saniye formatýna dönüþtürüyoruz.
        if (devamEdiyor)
        {
            gecenZaman += Time.deltaTime;
            int dakika = Mathf.FloorToInt(gecenZaman / 60f);
            int saniye=Mathf.FloorToInt(gecenZaman % 60f);

            // Hesaplanýlan süreyi dijital saat formatýnda ekrandaki metin bileþenine yazdýrýyoruz.
            if (oyunSayac != null)
            {
                oyunSayac.text = string.Format("{0:00}:{1:00}", dakika, saniye);
                
            }
        }
    }

    public void OyunuBaslat()
    {
        devamEdiyor = true;
    }
    public void OyunDurdur()
    {
        devamEdiyor = false;  
    }
    public float GetGecenZaman()
    {
        return gecenZaman;
    }
}
