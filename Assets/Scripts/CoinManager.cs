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
            }
            Destroy(gameObject);
        }
    }
}
