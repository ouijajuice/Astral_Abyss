using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject playerExplosion;
    public string hitTag;
    private GameObject killCounterScript;
    private GameObject boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            GameObject explosion = Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
            if (other.gameObject.CompareTag("Enemy"))
            {
                GameObject killCounter = GameObject.FindGameObjectWithTag("KillCounterObject");
                KillCounter killCounterScript = killCounter.GetComponent<KillCounter>();
                killCounterScript.killCount -= 1;
            }
            if (other.gameObject.CompareTag("Boss"))
            {
                GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                BossSpawn bossScript = boss.GetComponent<BossSpawn>();
                bossScript.bossHealth -= 1;
            }
        }
        Destroy(gameObject,5f);
    }
}
