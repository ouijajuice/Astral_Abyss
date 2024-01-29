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


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameObject targetObject = GameObject.FindWithTag("Player");
        target = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            StartCoroutine(Follow());
            isActive = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            dying = true;
            animator.SetBool("Dying", true);
            Destroy(gameObject, 1f);
        }

    }

    void Flip()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f,transform.localScale.y,transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }
    }

    IEnumerator Follow()
    {
        yield return new WaitForSeconds(waitTime);
        rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);

        Flip();
    }
}
