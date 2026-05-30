using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Staplebarrier : MonoBehaviour
{
    public float beklemesuresi = 1f;
    public float hareketsuresi = 0.5f;
    public float zMesafe = 3.5f;

    private float yukarýfýrlatma = 10f;
    private float ilerifýrlatma = 8f;

    private GameObject ustundekiKarekter;
    

    private void Start()
    {
        StartCoroutine(HareketDongusu());
    }
    private IEnumerator HareketDongusu()
    {
        if(CompareTag("Yatay"))
        { 
        Vector3 baslangicpoz=transform.position;
        Vector3 ileripos=baslangicpoz+new Vector3(0,0,zMesafe);
        bool ilerigiidyor = true;

            while (true)
            {
                yield return new WaitForSeconds(beklemesuresi);
                Vector3 neredem = transform.position;
                Vector3 nereye = ilerigiidyor ? ileripos : baslangicpoz;

                float gecenzaman = 0f;
                while (gecenzaman < hareketsuresi)
                {
                    transform.position = Vector3.Lerp(neredem, nereye, gecenzaman / hareketsuresi);
                    gecenzaman += Time.deltaTime;

                    yield return null;
                }
                transform.position = nereye;
                ilerigiidyor = !ilerigiidyor;
            }
        }
        if (CompareTag("Dikey"))
        {
            Vector3 baslangicpoz = transform.position;
            Vector3 geripos = baslangicpoz + new Vector3(0,-2f,0);
            bool ilerigiidyor = true;

            while (true)
            {
                yield return new WaitForSeconds(beklemesuresi);
                Vector3 neredem = transform.position;
                Vector3 nereye = ilerigiidyor ? geripos : baslangicpoz;

                if (!ilerigiidyor && ustundekiKarekter != null)
                {
                    Rigidbody playerRb = ustundekiKarekter.GetComponent<Rigidbody>();
                    if (playerRb != null)
                    {
                        Vector3 firlatmayonu = (Vector3.up * yukarýfýrlatma) + (-transform.forward* ilerifýrlatma);
                        playerRb.AddForce(firlatmayonu,ForceMode.Impulse);
                    }
                }

                float gecenzaman = 0f;
                while (gecenzaman < hareketsuresi)
                {
                    transform.position = Vector3.Lerp(neredem, nereye, gecenzaman / hareketsuresi);
                    gecenzaman += Time.deltaTime;

                    yield return null;
                }
                transform.position = nereye;
                ilerigiidyor = !ilerigiidyor;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ustundekiKarekter = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ustundekiKarekter = null;
        }
    }
}
