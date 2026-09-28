using UnityEngine;

public class YellowZoneTrigger : MonoBehaviour
{
    public EndArea endAreaManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (endAreaManager != null)
            {
                endAreaManager.SariAlanaGirildi(other.gameObject);
            }
        }
    }
}
