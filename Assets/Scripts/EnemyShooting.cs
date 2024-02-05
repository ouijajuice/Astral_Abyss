using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyProjectilePrefab;

    private float fireCooldown = 2f;
    public float fireCooldownDuration;

    // Update is called once per frame
    void Update()
    {
        if (fireCooldown <= 0f)
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
        GameObject projectile = Instantiate(enemyProjectilePrefab, firePoint.position, firePoint.rotation);
    }
}
