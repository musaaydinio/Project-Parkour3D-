using UnityEngine;

public class HealtController : MonoBehaviour
{
    public int maxCan=100;
    public int toplamPuan = 0;

    private int geçerliCan;
    private void Start()
    {
        geçerliCan = maxCan;
    }

    public void HasarAlma(int hasarMiktarý)
    {
        geçerliCan-=hasarMiktarý;

        if (geçerliCan <= 0)
        {
            geçerliCan=0;
            gameObject.SetActive(false);
        }
    }

    public void PuanTopla(int puanmiktarý)
    {
        toplamPuan += puanmiktarý;
    }

}
