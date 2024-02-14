using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject tentaclePrefab;

    [SerializeField]
    private float tentacleInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(tentacleInterval, tentaclePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}