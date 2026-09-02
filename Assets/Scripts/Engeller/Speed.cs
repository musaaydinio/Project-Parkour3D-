using Unity.VisualScripting;
using UnityEngine;

// Karakterin hýzýný geçici olarak artýran hýzlandýrma bantlarý veya boost alanlarýný yönetiyoruz.
public class Speed : MonoBehaviour
{
    public float hýzlýyürüme = 25f;
    public float hýzlýkosma = 25f;

    private float normalyurume = 3f;
    private float normalkosma = 6f;


    private void OnTriggerEnter(Collider other)
    {
        // Oyuncu hýzlandýrma alanýna temas ettiði anda yürüme ve koþma hýzlarýný belirlediðimiz yüksek deðerlere çekiyoruz.
        if (other.CompareTag("Player"))
        {
            PlayerAnimController oyuncu=other.GetComponent<PlayerAnimController>();
            if (oyuncu != null)
            {
                oyuncu.yürümeHizi=hýzlýyürüme;
                oyuncu.kosmaHizi = hýzlýkosma;
              
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Hýzlandýrma bandýndan çýkýldýðýnda karakterin hýzýný oyunun varsayýlan standart ayarlarýna geri döndürüyoruz.
        if (other.CompareTag("Player"))
        {
            PlayerAnimController oyuncu = other.GetComponent<PlayerAnimController>();
            if(oyuncu != null)
            {
                oyuncu.yürümeHizi=normalyurume;
                oyuncu.kosmaHizi=normalkosma;
               
            }
        }
    }
}
