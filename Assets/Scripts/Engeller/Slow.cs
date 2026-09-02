using Unity.VisualScripting;
using UnityEngine;

// Parkur haritasýndaki bataklýk veya zorlu zeminler gibi karakteri yavaþlatacak engelli alanlarýn mantýðýný kuruyoruz.
public class Slow : MonoBehaviour
{
    public float yavasyürüme = 1f;
    public float yavasziplama = 1f;
    public float yavaskosma = 1f;

    private float normalyürüme;
    private float normalkosma;
    private float normalzýplama;

    private void OnTriggerEnter(Collider other)
    {
        // Oyuncu yavaþlatma alanýna girdiðinde, alandan çýkarken geri vermek üzere karakterin mevcut hýz deðerlerini hafýzaya alýyoruz.
        if (other.CompareTag("Player"))
        {
            PlayerAnimController hareket = other.GetComponent<PlayerAnimController>();
            if(hareket!= null)
            {
                normalyürüme = hareket.yürümeHizi;
                normalkosma = hareket.kosmaHizi;
                normalzýplama = hareket.ziplamagücü;

                // Hafýzaya alma iþlemi bittikten sonra yavaþlatýlmýþ kýsýtlý deðerleri karaktere uyguluyoruz.
                hareket.yürümeHizi = yavasyürüme;
                hareket.kosmaHizi = yavaskosma;
                hareket.ziplamagücü = yavasziplama;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Oyuncu zorlu zeminden çýktýðýnda hafýzada tuttuðumuz orijinal hýz deðerlerini karaktere geri yüklüyoruz.
        if (other.CompareTag("Player"))
        {
            PlayerAnimController hareket= other.GetComponent<PlayerAnimController>();
            if(hareket!= null)
            {
                hareket.yürümeHizi = normalyürüme;
                hareket.kosmaHizi = normalkosma;
                hareket.ziplamagücü = normalzýplama;
            }
        }
    }
}
