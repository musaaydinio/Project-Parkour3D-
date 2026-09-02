using NUnit.Framework;
using UnityEngine;

// Parkurdaki hasar veren tuzaklarýn fiziksel temas durumlarýný ve oyuncuya vereceði hasarý yönetiyoruz.
public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private int hasarMiktarý;

    private void OnCollisionEnter(Collision collision)
    {
        // Herhangi bir fiziksel çarpýþma gerçekleþtiðinde çarpan nesnenin oyuncu olup olmadýðýný etiketi üzerinden doðruluyoruz.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Eðer oyuncuysa can kontrolcü bileþenine ulaþýp belirlediðimiz hasar miktarýný doðrudan iletiyoruz.
            collision.gameObject.GetComponent<HealtController>().HasarAlma(hasarMiktarý);
        }
    }
 
}

