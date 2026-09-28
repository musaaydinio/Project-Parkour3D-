using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Hedef (Oyuncu)")]
    public Transform target;

    [Header("Mesafe ve Yükseklik (Yerel Offset)")]
    public Vector3 tpsOffset = new Vector3(0f, 2.2f, -4.5f);

    [Header("Fare Hassasiyet Ayarlarý")]
    public float mouseSensitivity = 1f;

    [Header("Bakýþ Sýnýrlarý (Derece)")]
    public float minPitch = -20f; // Aþaðý bakýþ sýnýrý
    public float maxPitch = 50f;  // Yukarý bakýþ sýnýrý

    private float pitch = 0f;

    private void Start()
    {
        // Target atanmadýysa otomatik olarak üst objeyi (Player) hedef al
        if (target == null && transform.parent != null)
        {
            target = transform.parent;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // 1. Fare girdilerini al
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 2. Oyuncuyu (Üst Obje) yatayda döndür (Saða / Sola)
        target.Rotate(Vector3.up * mouseX);

        // 3. Kameranýn dikey açýsýný hesapla ve sýnýrla (Yukarý / Aþaðý)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // 4. SADECE YEREL (Local) rotasyonu güncelle
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // 5. Yerel offset'i açýyla çarparak dairesel yörüngeyi koru
        transform.localPosition = Quaternion.Euler(pitch, 0f, 0f) * tpsOffset;
    }
}