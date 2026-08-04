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
        geçerliCan = maxCan;
        animator = GetComponent<Animator>();
        characterController= GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        sonkayýtNoktasý=transform.position;
        CanbarýGuncelle();
    }

    public void SetCehckpoint(Vector3 yeninokta)
    {
        sonkayýtNoktasý = yeninokta;
        Debug.Log("Yeni Checkpoint Kayededildi:" + yeninokta);
    }

    public void HasarAlma(int hasarMiktarý)
    {
        if(respawnyapiliyor) return;

        geçerliCan -= hasarMiktarý;

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

        if(playerAnimController != null)playerAnimController.enabled = false;
        DeathAnimStart();
        StartCoroutine(RespawnRoutine(3f));
    }

    private void CanbarýGuncelle()
    {
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
        yield return new WaitForSeconds(delay);

        geçerliCan=maxCan;
        CanbarýGuncelle();

        GetComponent<SoundManager>().OyunMuzigiBaslat();

        if(characterController != null) characterController.enabled = false;
        transform.position = sonkayýtNoktasý;
        if(characterController !=null)characterController.enabled = true;

        if (rb != null)
        {
            rb.linearVelocity=Vector3.zero;
            rb.angularVelocity=Vector3.zero;
        }

        if(animator != null)animator.Rebind();
        if(playerAnimController!=null) playerAnimController.enabled = true ;

        respawnyapiliyor = false;
    }

    public void DeathAnimStart()
    {
        if(animator!=null)animator.SetTrigger("Die");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dýþalan"))
        {
            OLumSureci();                    
            CanbarýGuncelle();
        }
    }
    
}


