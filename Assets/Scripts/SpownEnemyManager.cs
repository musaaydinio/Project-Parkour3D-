using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpownEnemyManager : MonoBehaviour
{
    public GameObject objePrefab;

    public float spawnAralýðý = 4f;

    public float yokEtmeSuresi = 4f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpwanObje();
            yield return new WaitForSeconds(spawnAralýðý);
        }
    }

    void SpwanObje()
    {
        GameObject yenEngel=Instantiate(objePrefab, transform.position, Quaternion.identity);
        Destroy(yenEngel, 4f);
    }

 }
