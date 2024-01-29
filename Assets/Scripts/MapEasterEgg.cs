using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEasterEgg : MonoBehaviour
{
    public Transform player;
    public GameObject ground;
    // Update is called once per frame
    void Update()
    {
        if (player.position.x > 161f || player.position.x < -161f || player.position.y > 161f || player.position.y < -161f)
        {
            ground.SetActive(false);
        }
    }
}
