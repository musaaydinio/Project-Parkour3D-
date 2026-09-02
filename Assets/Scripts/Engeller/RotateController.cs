using UnityEngine;

// Dönen platformlarýn, çarklarýn veya testerelerin etiketlerine göre doðru eksende dönme hareketlerini ayarlýyoruz.
public class RotateController : MonoBehaviour
{
    public float donushizi = 100f;

    public Transform donecekTransform;

    private void Update()
    {
        // Objenin etiketine bakarak eðer yatay bir tuzaksa Y ekseni etrafýnda sürekli bir dönüþ kuvveti uyguluyoruz.
        if (CompareTag("Yatay"))
        {
            donecekTransform.Rotate(Vector3.up * donushizi * Time.deltaTime);
        }
        // Obje dikey bir tuzaksa dönüþü Z ekseni etrafýnda gerçekleþtiriyoruz.
        if (CompareTag("Dikey"))
        {
            donecekTransform.Rotate(Vector3.forward*donushizi * Time.deltaTime);
        }
    }   

}
