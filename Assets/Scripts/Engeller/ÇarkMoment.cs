using UnityEngine;

// Parkurdaki dönen tuzakların hem kendi etrafında dönmesini hem de belirli bir hat üzerinde sürekli gidip gelmesini sağlıyoruz.
public class ÇarkMoment : MonoBehaviour
{
    public Transform carkobjesi;
    public float dönüshizi = 100f;
    public float harekethizi = 2f;
    public float maxPos = 1.25f;
    public float minPos = -1.25f;

    private void Update()
    {
        // Tuzağın kendi ekseni etrafında kesintisiz bir şekilde dönmesini sağlıyoruz.
        carkobjesi.Rotate(Vector3.right * dönüshizi * Time.deltaTime);
        // Mathf.PingPong fonksiyonunu kullanarak tuzağın belirlediğimiz minimum ve maksimum noktalar
        // (minPos - maxPos) arasında sonsuz bir döngüde gidip gelmesini hesaplıyoruz.
        float hareketYonu = Mathf.PingPong(Time.time * harekethizi, maxPos - minPos) + minPos;
        // Hesaplanan bu ileri-geri hareket değerini, tuzağın yerel Z eksenine uygulayarak hareketi fizikselleştiriyoruz.
        carkobjesi.transform.localPosition=new Vector3(carkobjesi.transform.localPosition.x,
        carkobjesi.transform.localPosition.y,hareketYonu);
    }
}
