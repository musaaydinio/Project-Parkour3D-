using UnityEngine;

public class CoinManager : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealtController health =other.GetComponent<HealtController>();
            if (health != null)
            {
               health.SetCehckpoint(transform.position);

                SoundManager soundManager = FindAnyObjectByType<SoundManager>();
                if (soundManager != null)
                {
                    soundManager.CheckPointCal();
                }

                MeshRenderer mr = GetComponent<MeshRenderer>();
                if (mr != null) mr.enabled = false;

                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;

                Destroy(gameObject, 1f);
            }
           
        }
    }
}
