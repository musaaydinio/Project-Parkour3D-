using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// Parkur haritasýndaki hareketli zýmba bariyerlerini ve oyuncuyu havaya fýrlatan platform sistemlerini yönetiyoruz.
public class Staplebarrier : MonoBehaviour
{
    public float beklemesuresi = 1f;
    public float hareketsuresi = 0.5f;
    public float zMesafe = 3.5f;
    public float xMesafe = 0;
    public float yMesafe = -2f;

    [SerializeField] float yukarýfýrlatma = 10f;
    [SerializeField] float ilerifýrlatma = 8f;

    private GameObject ustundekiKarekter;
    

    private void Start()
    {
        // Oyun baþladýðýnda objenin etiketine göre uygun olan hareket döngüsünü baþlatýyoruz.
        StartCoroutine(HareketDongusu());
    }
    private IEnumerator HareketDongusu()
    {
        // Engel yatay olarak etiketlenmiþse belirlediðimiz X ve Z mesafelerinde sürekli ileri geri gitmesini saðlýyoruz.
        if (CompareTag("Yatay"))
        { 
        Vector3 baslangicpoz=transform.position;
        Vector3 ileripos=baslangicpoz+new Vector3(xMesafe,0,zMesafe);
        bool ilerigiidyor = true;

            while (true)
            {
                yield return new WaitForSeconds(beklemesuresi);
                Vector3 neredem = transform.position;
                Vector3 nereye = ilerigiidyor ? ileripos : baslangicpoz;

                float gecenzaman = 0f;

                // Platformun iki nokta arasýndaki hareketini belirlediðimiz süre boyunca pürüzsüz bir þekilde kaydýrýyoruz.
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
        // Engel dikey olarak etiketlenmiþse aþaðý inip aniden yukarý çýkarak tuzak iþlevi görmesini saðlýyoruz.
        if (CompareTag("Dikey"))
        {
            Vector3 baslangicpoz = transform.position;
            Vector3 geripos = baslangicpoz + new Vector3(0,yMesafe,0);
            bool ilerigiidyor = true;

            while (true)
            {
                yield return new WaitForSeconds(beklemesuresi);
                Vector3 neredem = transform.position;
                Vector3 nereye = ilerigiidyor ? geripos : baslangicpoz;

                // Platform aniden yukarý çýkarken üzerinde oyuncu varsa ona yukarý ve ileri yönlü ani bir fiziksel kuvvet uyguluyoruz.
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
        // Fýrlatma iþlemini yapabilmek için platformun üzerine çýkan oyuncuyu hafýzaya alýyoruz.
        if (collision.gameObject.CompareTag("Player"))
            if (collision.gameObject.CompareTag("Player"))
        {
            ustundekiKarekter = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        // Oyuncu platformdan indiðinde fýrlatma kuvvetinin boþluða uygulanmamasý için hafýzayý temizliyoruz.
        if (collision.gameObject.CompareTag("Player"))
        {
            ustundekiKarekter = null;
        }
    }
}
