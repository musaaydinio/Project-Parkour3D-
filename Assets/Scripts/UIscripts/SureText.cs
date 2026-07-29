using TMPro;
using UnityEngine;

public class SureText : MonoBehaviour
{
    public TextMeshProUGUI oyunSayac;

    private float gecenZaman = 0f;
    private bool devamEdiyor=true;

    private void Update()
    {
        if (devamEdiyor)
        {
            gecenZaman += Time.deltaTime;
            int dakika = Mathf.FloorToInt(gecenZaman / 60f);
            int saniye=Mathf.FloorToInt(gecenZaman % 60f);           

            if(oyunSayac != null)
            {
                oyunSayac.text = string.Format("{0:00}:{1:00}", dakika, saniye);
                
            }
        }
    }
    public void OyunDurdur()
    {
        devamEdiyor = false;  
    }
}
