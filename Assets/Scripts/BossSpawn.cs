using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class BossSpawn : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float speed;
    private EdgeCollider2D edgeCollider;
    private GameObject killCounterScript;
    public int bossHealth;
    public int bossMaxHealth;
    public GameObject bossDeathParticles;
    private int alive = 0;
    private Animator animator;
    public string winScreen;
    public AudioSource source;
    private bool audioPlayed = false;
    public Color hitColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bossHealth = bossMaxHealth;
        edgeCollider.enabled = false;
    }

    private void Update()
    {
        GameObject killCounter = GameObject.FindGameObjectWithTag("KillCounterObject");
        KillCounter killCounterScript = killCounter.GetComponent<KillCounter>();
        if (killCounterScript.killCount == 0)
        {
            edgeCollider.enabled = true;
            if (alive == 0)
            {
                alive = 1;
            }
            
        }
        if (bossHealth <= 0)
        {
            if (alive == 1)
            {
                Instantiate(bossDeathParticles, transform.position, Quaternion.identity);
                if (audioPlayed == false)
                {
                    source.Play();
                }
                audioPlayed = true;
            }
            
            alive = -1;
            animator.SetBool("Dying", true);
            Invoke("WinScreen", 3);
            Destroy(gameObject, 3f);
        }
    }

    void FixedUpdate()
    {
        GameObject killCounter = GameObject.FindGameObjectWithTag("KillCounterObject");
        KillCounter killCounterScript = killCounter.GetComponent<KillCounter>();
        if (killCounterScript.killCount == 0)
        {
            rb.position = Vector2.MoveTowards(rb.position, target.position, speed * Time.deltaTime);
        }
    }

    void WinScreen()
    {
        SceneManager.LoadScene(winScreen);
        //Debug.Log("Invoking");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            spriteRenderer.color = hitColor;
        }
        Invoke("ResetColor", .2f);
    }

    void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }

}
