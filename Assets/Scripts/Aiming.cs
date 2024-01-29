using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Rigidbody2D firePointRb;

    public Camera cam;
    Vector2 mousePos;

    public Transform posTarget;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        firePointRb.position = posTarget.position;
    }

    void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - firePointRb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePointRb.SetRotation(angle);
    }
}
