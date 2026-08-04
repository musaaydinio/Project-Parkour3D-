using UnityEngine;
using TMPro;

public class SkorPanel : MonoBehaviour
{
    public TextMeshProUGUI skorText;

    void OnEnable()
    {
        SkorlariYukle();
    }

    public void SkorlariYukle()
    {
        if (skorText == null) return;

        skorText.text = "";

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Skor_" + i))
            {
                float sure = PlayerPrefs.GetFloat("Skor_" + i);
                int min = (int)(sure / 60);
                int sec = (int)(sure % 60);

                skorText.text += $"{i + 1}.   {min:00}:{sec:00}\n";
            }
            else
            {
                skorText.text += $"{i + 1}.   --:--\n";
            }
        }
    }
}