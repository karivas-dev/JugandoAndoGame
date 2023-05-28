using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EntryNemy : MonoBehaviour
{
    private PlayerPlatformerController scriptToDeactivate;
    private TimelineManager timelineManager;
    public GameObject elementToDeactivate;
    public GameObject healthBar;
    public GameObject screenBG;
    public GameObject director;
    public GameObject player;
    public GameObject timer;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("idle", false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))  
        {
            player.GetComponent<PlayerPlatformerController>().enabled = false;       
            director.GetComponent<TimelineManager>().enabled = true;
            elementToDeactivate.SetActive(false);
            anim.SetBool("idle", true);
            healthBar.SetActive(true);
            screenBG.SetActive(true);
            /*timer.SetActive(true);*/
        }   
    }
}
