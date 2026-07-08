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
    private void Start()
    {
        geçerliCan = maxCan;
        animator = GetComponent<Animator>();
        CanbarýGuncelle();
    }

    public void RestartGame(float delay)
    {
        StartCoroutine(RestartRoutine(delay));
    }
    public void HasarAlma(int hasarMiktarý)
    {
        geçerliCan-=hasarMiktarý;

        if (geçerliCan <= 0)
        {
            geçerliCan=0;
           if (playerAnimController != null) playerAnimController.enabled = false;
            DeathAnimStart();
            RestartGame(3);
        }
        CanbarýGuncelle();
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

    public void PuanTopla(int puanmiktarý)
    {
        toplamPuan += puanmiktarý;
    }

    public void DeathAnimStart()
    {
        animator.SetTrigger("Die");
    }
    private IEnumerator RestartRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dýþalan"))
        {
            geçerliCan = 0;
            DeathAnimStart();
            RestartGame(3);
            CanbarýGuncelle();
        }
    }
    
}


