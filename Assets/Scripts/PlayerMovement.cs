using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 PlayerInput;
    private float lastDirectionMoved;
    private bool isFacingRight;
    private Animator animator;
    private bool firing;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (PlayerInput.x != 0f)
        {
            lastDirectionMoved = PlayerInput.x;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            firing = true;
            animator.SetBool("Firing", true);
        }

        Invoke("FiringFalse", 1f);

        Flip();
    }
    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * moveSpeed;

        if (rb.position.x <= -7f)
        {
            moveForce.x = 1f;
        }
        if (rb.position.x >= 7f)
        {
            moveForce.x = -1f;
        }
        if (rb.position.y <= -7f)
        {
            moveForce.y = 1f;
        }
        if (rb.position.y >= 7f)
        {
            moveForce.y = -1f;
        }
        

        rb.velocity = moveForce;
    }

    private void Flip()
    {
        if (isFacingRight && PlayerInput.x > 0f || !isFacingRight && PlayerInput.x < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void FiringFalse()
    {
        firing = false;
        animator.SetBool("Firing", false);
    }
}