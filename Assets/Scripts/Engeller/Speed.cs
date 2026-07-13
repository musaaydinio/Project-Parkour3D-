using Unity.VisualScripting;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float hýzlýyürüme = 25f;
    public float hýzlýkosma = 25f;

    private float normalyurume = 3f;
    private float normalkosma = 6f;


    private void OnTriggerEnter(Collider other)
    {
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
