using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHint : MonoBehaviour
{
    public GameObject canvas;

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        if(player.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
}
