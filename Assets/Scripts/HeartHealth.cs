using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealth : MonoBehaviour
{
    private Animator animator;
    public int heartChangeValue;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerScript = playerObject.GetComponent<PlayerMovement>();
        if (playerScript.health <= heartChangeValue)
        {
            animator.SetBool("bleedingHeart", true);
        }
    }
}
