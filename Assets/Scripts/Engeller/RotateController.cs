using UnityEngine;

public class RotateController : MonoBehaviour
{
    public float donushizi = 100f;

    public Transform donecekTransform;

    private void Update()
    {
        if (CompareTag("Yatay"))
        {
            donecekTransform.Rotate(Vector3.up * donushizi * Time.deltaTime);
        }
        if(CompareTag("Dikey"))
        {
            donecekTransform.Rotate(Vector3.forward*donushizi * Time.deltaTime);
        }
    }   

}
