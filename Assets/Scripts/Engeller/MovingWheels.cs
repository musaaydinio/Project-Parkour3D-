using UnityEngine;

// Engelin baþlangýç noktasýný referans alarak etrafýndaki dört farklý nokta arasýnda sürekli devriye gezmesini saðlýyoruz.
public class MovingWheels : MonoBehaviour
{
    public float mesafe = 3f;
    public float hýz = 3f;

    private Vector3 baslangic;
    private Vector3[] hedefler;
    private int index;

    private void Start()
    {
        baslangic=transform.position;
        // Oyun baþladýðýnda objenin merkezine göre gideceði dört uç noktayý (sað, sol, ileri, geri) hesaplayýp rota dizimize kaydediyoruz.
        hedefler = new Vector3[]
        {
            baslangic +new Vector3(mesafe,0,0),
            baslangic +new Vector3(-mesafe,0,0),
            baslangic +new Vector3(0,0,mesafe),
            baslangic +new Vector3(0,0,-mesafe),
        };
    }
    private void Update()
    {
        // Objeyi dizideki sýradaki hedefe doðru belirlediðimiz hýzda pürüzsüz bir þekilde ilerletiyoruz.
        transform.position = Vector3.MoveTowards(transform.position, hedefler[index], hýz * Time.deltaTime);
        // Obje hedef noktaya çok yaklaþtýðýnda sýradaki hedefe geçiþ yapýyoruz. Mod alma iþlemi sayesinde dizi bitince tekrar baþa dönmesini garantiliyoruz.
        if (Vector3.Distance(transform.position, hedefler[index]) < 0.05f)
        {
            index=(index+1)% hedefler.Length;
        }
    }
}
