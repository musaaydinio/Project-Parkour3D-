using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Staplebarrier : MonoBehaviour
{
    public float beklemesuresi = 1f;
    public float hareketsuresi = 0.5f;

    public float zMesafe = 3.5f;

    private void Start()
    {
        StartCoroutine(HareketDongusu());
    }
    private IEnumerator HareketDongusu()
    {
        Vector3 baslangicpoz=transform.position;
        Vector3 ileripos=baslangicpoz+new Vector3(0,0,zMesafe);
        bool ilerigiidyor = true;

        while (true)
        {
            yield return new WaitForSeconds(beklemesuresi);
            Vector3 neredem=transform.position;
            Vector3 nereye = ilerigiidyor ? ileripos : baslangicpoz;

            float gecenzaman = 0f;
            while (gecenzaman<hareketsuresi)
            {
                transform.position=Vector3.Lerp(neredem,nereye,gecenzaman/hareketsuresi);
                gecenzaman += Time.deltaTime;

                yield return null;
            }
            transform.position=nereye;
            ilerigiidyor = !ilerigiidyor;
        }
    }

}
