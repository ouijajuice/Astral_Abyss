using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossSpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject tentaclePrefab;

    [SerializeField]
    private float tentacleInterval;

    private GameObject killCounterScript;

    private bool done = false;
    // Start is called before the first frame update
    void Update()
    {
        GameObject killCounter = GameObject.FindGameObjectWithTag("KillCounterObject");
        KillCounter killCounterScript = killCounter.GetComponent<KillCounter>();
        if (killCounterScript.killCount <= 0 && done == false)
        {
            StartCoroutine(spawnEnemy(tentacleInterval, tentaclePrefab));
            done = true;
        }
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}