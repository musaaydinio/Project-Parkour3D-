using TMPro;
using UnityEngine;

// Oyuncunun parkuru bitirme sürelerini cihaz hafýzasýndan çekip skor tablosunda dinamik olarak listeliyoruz.
public class SkorPanel : MonoBehaviour
{
    public TextMeshProUGUI skorText;

    // Panel her aktif edildiðinde listenin güncel kalmasýný saðlýyoruz.
    void OnEnable()
    {
        SkorlariYukle();
    }

    public void SkorlariYukle()
    {
        if (skorText == null) return;

        // Listeyi doldurmadan önce içindeki eski metinleri tamamen temizliyoruz.
        skorText.text = "";

        // Veritabanýndaki ilk 10 skoru çekmek için bir döngü baþlatýyoruz.
        for (int i = 0; i < 10; i++)
        {
            // Eðer o sýraya ait kaydedilmiþ bir skor varsa iþlemi yapýyoruz.
            if (PlayerPrefs.HasKey("Skor_" + i))
            {
                float sure = PlayerPrefs.GetFloat("Skor_" + i);

                // Toplam saniyeyi dakika ve saniye formatýna dönüþtürüyoruz.
                int min = (int)(sure / 60);
                int sec = (int)(sure % 60);

                skorText.text += $"{i + 1}.   {min:00}:{sec:00}\n";
            }
            else
            {
                // Henüz kaydedilmiþ bir skor yoksa boþ olduðunu belirten varsayýlan çizgileri ekliyoruz.
                skorText.text += $"{i + 1}.   --:--\n";
            }
        }
    }
}
