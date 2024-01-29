using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject playerProjectilePrefab;

    public float projectileForce;
    private float fireCooldown = 0f;
    public float fireCooldownDuration;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireCooldownDuration;
        }
        else
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(playerProjectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
    }
}
