using UnityEngine;

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
        transform.position = Vector3.MoveTowards(transform.position, hedefler[index], hýz * Time.deltaTime);
        if (Vector3.Distance(transform.position, hedefler[index]) < 0.05f)
        {
            index=(index+1)% hedefler.Length;
        }
    }
}
