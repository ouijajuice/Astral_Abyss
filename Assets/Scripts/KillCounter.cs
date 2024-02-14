using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public int killCount;
    public TextMeshProUGUI killText;
    // Update is called once per frame
    void Update()
    {
        killText.text = killCount.ToString();
        if (killCount < 0)
        {
            killCount = 0;
        }
    }
}
