using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EntryNemy : MonoBehaviour
{
    public GameObject player;
    public GameObject director;
    private PlayerPlatformerController scriptToDeactivate;
    private TimelineManager timelineManager;
    public bool isInRange = false;
    private float dirX;
    public Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("idle", false);
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        SetIdle();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))  
        {
            player.GetComponent<PlayerPlatformerController>().enabled = false;       
            director.GetComponent<TimelineManager>().enabled = true;
        }   
    }

    private void SetIdle() 
    {   
        if (dirX >= -1.37) 
            anim.SetBool("idle", true); 
    }
}
