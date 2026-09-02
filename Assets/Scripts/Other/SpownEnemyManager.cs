using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// Parkurda oyuncuya zorluk çýkarmak için yuvarlanan
// kütük benzeri hareketli engellerin belirli aralýklarla sahneye üretilmesini saðlýyoruz.
public class SpownEnemyManager : MonoBehaviour
{
    public GameObject objePrefab;

    public float spawnAralýðý = 4f;

    public float yokEtmeSuresi = 4f;

    private void Start()
    {
        // Üretim döngüsünü oyun baþlar baþlamaz aktif ediyoruz.
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        // Sonsuz bir döngü kurarak, belirlediðimiz saniye aralýklarýyla sahneye sürekli yeni bir engel (odun) çaðýrýyoruz.
        while (true)
        {
            SpwanObje();
            yield return new WaitForSeconds(spawnAralýðý);
        }
    }

    void SpwanObje()
    {
        // Yeni engeli objenin bulunduðu konuma üretiyor ve bellek (RAM) þiþmesini önlemek için belirlediðimiz süre sonunda sahneden siliyoruz.
        GameObject yenEngel =Instantiate(objePrefab, transform.position, Quaternion.identity);
        Destroy(yenEngel, 4f);
    }

 }
