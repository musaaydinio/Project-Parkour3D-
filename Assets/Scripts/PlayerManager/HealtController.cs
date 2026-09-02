using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealtController : MonoBehaviour
{
    private Animator animator;
    public int maxCan=100;
    public int toplamPuan = 0;

    private int geçerliCan;

    public Image canbarý;
    public TextMeshProUGUI canyazisi;

    public PlayerAnimController playerAnimController;

    private Vector3 sonkayýtNoktasý;
    private CharacterController characterController;
    private Rigidbody rb;

    private bool respawnyapiliyor=false;
    private void Start()
    {
        // Oyun baþladýðýnda karakterin canýný tam kapasiteye eþitliyor, gerekli fizik ve animasyon bileþenlerini hafýzaya alýyoruz.
        geçerliCan = maxCan;
        animator = GetComponent<Animator>();
        characterController= GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        // Karakterin oyuna baþladýðý ilk pozisyonu, ilk kayýt noktasý olarak belirliyoruz.
        sonkayýtNoktasý = transform.position;
        CanbarýGuncelle();
    }

    public void SetCehckpoint(Vector3 yeninokta)
    {
        // Karakter haritada yeni bir güvenli alana ulaþtýðýnda, öldükten sonra doðacaðý yeri bu yeni koordinatlarla deðiþtiriyoruz.
        sonkayýtNoktasý = yeninokta;
        Debug.Log("Yeni Checkpoint Kayededildi:" + yeninokta);
    }

    public void HasarAlma(int hasarMiktarý)
    {
        // Karakter zaten ölüm döngüsündeyse üst üste hasar alýp sistemi bozmasýný engelliyoruz.
        if (respawnyapiliyor) return;

        geçerliCan -= hasarMiktarý;

        // Can sýfýra veya eksiye düþtüðünde doðrudan ölüm iþlemlerini baþlatýyoruz.
        if (geçerliCan <= 0)
        {
            OLumSureci();
        }

        GetComponent<SoundManager>().HasarSesiCal();

            CanbarýGuncelle();
    }

    private void OLumSureci()
    {
        if(respawnyapiliyor) return ;
        respawnyapiliyor = true;

        geçerliCan = 0;

        GetComponent<SoundManager>().OlumSesical();

        // Karakter öldüðü an hareket etmesini engellemek için animasyon ve kontrolcü scriptini devre dýþý býrakýyoruz.
        if (playerAnimController != null)playerAnimController.enabled = false;
        DeathAnimStart();
        // 3 saniyelik bekleme süresinin ardýndan yeniden doðma sürecini tetikliyoruz.
        StartCoroutine(RespawnRoutine(3f));
    }

    private void CanbarýGuncelle()
    {
        // Ekranda bulunan UI can barýnýn doluluk oranýný ve metin bilgisini güncel can deðerine göre ayarlýyoruz.
        if (canbarý != null)
        {
            canbarý.fillAmount = (float)geçerliCan / maxCan;
        }
        if( canyazisi != null)
        {
            canyazisi.text=geçerliCan.ToString();
        }
    }

    private IEnumerator RespawnRoutine(float delay)
    {
        // Ölüm animasyonunun izlenmesi için belirlediðimiz süre kadar bekliyoruz.
        yield return new WaitForSeconds(delay);

        geçerliCan=maxCan;
        CanbarýGuncelle();

        GetComponent<SoundManager>().OyunMuzigiBaslat();

        // Iþýnlanma sýrasýnda CharacterController fiziksel çakýþma yaratmasýn diye önce kapatýp, taþýma bitince tekrar açýyoruz.
        if (characterController != null) characterController.enabled = false;
        transform.position = sonkayýtNoktasý;
        if(characterController !=null)characterController.enabled = true;

        // Karakter düþerken öldüyse üzerinde kalan düþüþ hýzýný ve ivmesini tamamen sýfýrlýyoruz.
        if (rb != null)
        {
            rb.linearVelocity=Vector3.zero;
            rb.angularVelocity=Vector3.zero;
        }
        // Animasyonlarý varsayýlan haline getirip oyuncuya hareket kontrolünü geri veriyoruz.
        if (animator != null)animator.Rebind();
        if(playerAnimController!=null) playerAnimController.enabled = true ;

        respawnyapiliyor = false;
    }

    public void DeathAnimStart()
    {
        if(animator!=null)animator.SetTrigger("Die");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Parkur haritasýndan aþaðý düþüldüðünde dýþ alan tetikleyicisine çarpýlýrsa doðrudan ölümü gerçekleþtiriyoruz.
        if (other.CompareTag("Dýþalan"))
        {
            OLumSureci();                    
            CanbarýGuncelle();
        }
    }
    
}


