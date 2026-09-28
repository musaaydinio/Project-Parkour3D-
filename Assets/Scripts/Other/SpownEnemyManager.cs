using System.Collections;
using UnityEngine;

// Parkurda oyuncuya zorluk çýkarmak için yuvarlanan
// kütük benzeri hareketli engellerin belirli aralýklarla sahneye üretilmesini saðlýyoruz.
public class SpownEnemyManager : MonoBehaviour
{
    [Header("Ayarlar")]
    public GameObject objePrefab;
    public float spawnAralýðý = 4f;
    public float yokEtmeSuresi = 4f; 

    private Coroutine spawnCoroutine; // Döngüyü kontrol etmek için referans tutuyoruz.

    private void OnEnable()
    {
        // DistanceActivator açtýðýnda veya baþlangýçta döngüyü baþlat.
        // Önce varsa eski döngüyü durduruyoruz ki üst üste binmesin.
        if (spawnCoroutine != null) StopCoroutine(spawnCoroutine);
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        // Script kapatýldýðýnda (DistanceActivator kapattýðýnda) çalýþan döngüyü durdur.
        // Bu sayede kütük üretimi durur.
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    IEnumerator SpawnRoutine()
    {
        // Sonsuz bir döngü kurarak, belirlediðimiz saniye aralýklarýyla sahneye sürekli yeni bir engel çaðýrýyoruz.
        // Script kapandýðýnda OnDisable tetikleneceði için bu döngü duracaktýr.
        while (true)
        {
            SpwanObje();
            yield return new WaitForSeconds(spawnAralýðý);
        }
    }

    void SpwanObje()
    {
        // Eðer script bir þekilde devre dýþý kaldýysa ama döngü son bir kez çalýþtýysa üretimi engelle.
        if (!enabled) return;

        // Yeni engeli objenin bulunduðu konuma üretiyor ve bellek (RAM) þiþmesini önlemek için belirlediðimiz süre sonunda sahneden siliyoruz.
        GameObject yeniEngel = Instantiate(objePrefab, transform.position, Quaternion.identity);

        Destroy(yeniEngel, yokEtmeSuresi);
    }
}
