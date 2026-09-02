using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef;
    public float takiphizi = 10f;
    public float fareHassasiyeti = 300f;

    public float arkaMesafe = 4f;

    private void Start()
    {
        // Oyun baþladýðýnda, farenin ekrandan dýþarý çýkmasýný engellemek için imleci oyun penceresinin ortasýna kilitliyoruz.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Karakterin fiziksel hareketleri bittikten sonra titremeleri önlemek adýna kamera güncellemelerini LateUpdate içinde yapýyoruz.
    private void LateUpdate()
    {
        // Fareden gelen yatay eksen hareketini alarak hedef karakterimizi kendi ekseni etrafýnda döndürüyoruz.
        float fareX = Input.GetAxisRaw("Mouse X") * fareHassasiyeti * Time.deltaTime;
        hedef.Rotate(Vector3.up * fareX);

        // Kameranýn karakterin tam arkasýnda ve biraz yukarýsýnda duracaðý ideal konumu matematiksel olarak hesaplýyoruz.
        Vector3 hedefPos = hedef.position - (hedef.forward * arkaMesafe);
        hedefPos.y = hedef.position.y + 2.5f;

        // Kamerayý hedef pozisyona aniden ýþýnlamak yerine, Lerp fonksiyonu ile yumuþak bir þekilde süzülerek gitmesini saðlýyoruz.
        transform.position = Vector3.Lerp(transform.position, hedefPos, takiphizi * Time.deltaTime);

        // Kameranýn merceðini karakterin hafifçe yukarýsýna odaklayarak daha iyi ve geniþ bir görüþ açýsý sunuyoruz.
        transform.LookAt(hedef.position + Vector3.up * 1.5f);
    }
}