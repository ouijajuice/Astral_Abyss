using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyExplosion;
    public string hitTag;
    public float speed;
    private Transform playerTransform;
    private Vector2 playerPos;
    private Vector2 direction;
    public float projectileForce;
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        playerTransform = playerObject.transform;
        playerPos = playerTransform.position;
        Vector2 direction = (playerPos - (Vector2)transform.position).normalized;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * projectileForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(hitTag))
        {
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();
            playerScript.health -= 1;
        }
        Destroy(gameObject, 5f);
    }
}
