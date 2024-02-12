using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject playerExplosion;
    public string hitTag;
    private GameObject killCounterScript;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(hitTag))
        {
            GameObject explosion = Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
            if (hitTag == "Enemy")
            {
                GameObject killCounter = GameObject.FindGameObjectWithTag("KillCounterObject");
                KillCounter killCounterScript = killCounter.GetComponent<KillCounter>();
                killCounterScript.killCount -= 1;
            }
        }
        Destroy(gameObject,5f);
    }
}
