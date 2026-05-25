using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealtController : MonoBehaviour
{
    private Animator animator;
    public int maxCan=100;
    public int toplamPuan = 0;
   

    private int geçerliCan;

    public PlayerAnimController playerAnimController;
    private void Start()
    {
        geçerliCan = maxCan;
        animator = GetComponent<Animator>();
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

}
