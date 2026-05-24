using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef;
    public float takiphizi = 10f;
    public float fareHassasiyeti = 300f;

    // Kameranýn karakterden ne kadar geride duracaðý (Z ekseni)
    public float arkaMesafe = 4f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        // 1. Sadece farenin sað/sol hareketini al ve karakteri döndür
        float fareX = Input.GetAxisRaw("Mouse X") * fareHassasiyeti * Time.deltaTime;
        hedef.Rotate(Vector3.up * fareX);

        // 2. Kameranýn gideceði yeri karakterin tam arkasý olarak belirle
        Vector3 hedefPos = hedef.position - (hedef.forward * arkaMesafe);

        // ÝÞTE SENÝN ÇÖZÜMÜN: Kameranýn yüksekliðini (Y) kesin ve zorunlu olarak 2.5'e sabitliyoruz!
        hedefPos.y = hedef.position.y + 2.5f;

        // 3. Kamerayý bu yeni sabitlenmiþ pozisyona yumuþakça götür
        transform.position = Vector3.Lerp(transform.position, hedefPos, takiphizi * Time.deltaTime);

        // 4. Kameranýn merceðini her zaman karakterin boyun hizasýna sabitle
        transform.LookAt(hedef.position + Vector3.up * 1.5f);
    }
}