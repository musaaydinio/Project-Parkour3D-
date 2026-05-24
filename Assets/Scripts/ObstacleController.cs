using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private int hasarMiktarý;
    // iki nesnenin çarpýþtýðý anda gerçeklerþir.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealtController>().HasarAlma(hasarMiktarý);
        }
    }
 
}

