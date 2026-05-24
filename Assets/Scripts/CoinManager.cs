using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] int puanMiktari = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealtController>().PuanTopla(puanMiktari);
            Destroy(gameObject);
        }
    }
}
