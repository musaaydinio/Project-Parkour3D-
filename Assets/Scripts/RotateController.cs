using UnityEngine;

public class RotateController : MonoBehaviour
{
    public float donushizi = 100f;

    public Transform donecekTransform;

    private void Update()
    {
        donecekTransform.Rotate(Vector3.up*donushizi*Time.deltaTime);
    }

}
