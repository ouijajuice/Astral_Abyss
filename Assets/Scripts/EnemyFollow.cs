using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;
    private Transform target;
    public float speed;
    private bool dying;
    public float waitTime;
    private bool isActive = false;
    private float followTimer = 0f;
    public float followDelay = 1f;
    public bool rangedFollow;
    public float stoppingDistance;
    public GameObject spawnParticles;
    public float spawnParticleYDist;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameObject targetObject = GameObject.FindWithTag("Player");
        target = targetObject.transform;
        GameObject spawnParts = Instantiate(spawnParticles, new Vector3(transform.position.x,transform.position.y-spawnParticleYDist,transform.position.z), Quaternion.identity);
        Destroy(spawnParts, 1f);
        gameObject.GetComponent<EdgeCollider2D>().enabled = false;
    }

    void FixedUpdate()
    {

        if (dying == false)
        {
            
            followTimer += Time.deltaTime;
            if (followTimer >= followDelay)
            {
                Follow();
                Flip();
                gameObject.GetComponent<EdgeCollider2D>().enabled = true;
            }
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            dying = true;
            animator.SetBool("Dying", true);
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            Destroy(gameObject, 1f);
        }

    }

    void Flip()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
    }

    void Follow()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        //Debug.Log("Distance to Player: " + distanceToPlayer);
        if (rangedFollow == false)
        {
            //Debug.Log("Ranged Follow False | Following");
            rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);
        }
        else if (rangedFollow == true && distanceToPlayer >= stoppingDistance)
        {
            //Debug.Log("Ranged Follow True | Following");
            rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);
        }
    }

}
