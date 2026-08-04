using UnityEngine;

public class StartArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SureText sayac = FindFirstObjectByType<SureText>();
            if (sayac != null)
            {
                sayac.OyunuBaslat();
            }
           
            SoundManager soundManager = FindAnyObjectByType<SoundManager>();
            if (soundManager != null)
            {
                soundManager.BaslangiSesiCal();
            }
         
            MeshRenderer mr = GetComponent<MeshRenderer>();
            if (mr != null) mr.enabled = false;

            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            Destroy(gameObject, 3f);
        }
    }
}