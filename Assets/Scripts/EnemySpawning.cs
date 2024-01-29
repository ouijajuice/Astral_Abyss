using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    //[SerializeField]
    //private GameObject rangedEnemyPrefab;

    [SerializeField]
    private float enemyInterval;

    //[SerializeField]
    //private float rangedEnemyInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
        //StartCoroutine(spawnEnemy(rangedEnemyInterval, rangedEnemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
