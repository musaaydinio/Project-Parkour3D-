using Unity.VisualScripting;
using UnityEngine;

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
        if (other.CompareTag("Player"))
        {
            PlayerAnimController hareket = other.GetComponent<PlayerAnimController>();
            if(hareket!= null)
            {
                normalyürüme = hareket.yürümeHizi;
                normalkosma = hareket.kosmaHizi;
                normalzýplama = hareket.ziplamagücü;

                hareket.yürümeHizi = yavasyürüme;
                hareket.kosmaHizi = yavaskosma;
                hareket.ziplamagücü = yavasziplama;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
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
