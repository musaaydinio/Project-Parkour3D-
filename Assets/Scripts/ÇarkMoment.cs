using UnityEngine;

public class ÇarkMoment : MonoBehaviour
{
    public Transform carkobjesi;
    public float dönüshizi = 100f;
    public float harekethizi = 2f;
    public float maxPos = 1.25f;
    public float minPos = -1.25f;

    private void Update()
    {
        carkobjesi.Rotate(Vector3.right * dönüshizi * Time.deltaTime);
        float hareketYonu = Mathf.PingPong(Time.time * harekethizi, maxPos - minPos) + minPos;
        carkobjesi.transform.localPosition=new Vector3(carkobjesi.transform.localPosition.x,
        carkobjesi.transform.localPosition.y,hareketYonu);
    }
}
