using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class TentacleScript : MonoBehaviour
{
    private BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        Invoke("EnableCollider", 1f);
        Destroy(gameObject, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerScript = playerObject.GetComponent<PlayerMovement>();
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.health -= 1;
        }

    }

    private void EnableCollider()
    {
        collider.enabled = true;
    }
}
