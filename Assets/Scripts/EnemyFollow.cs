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


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameObject targetObject = GameObject.FindWithTag("Player");
        target = targetObject.transform;
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
        rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);
    }

}
