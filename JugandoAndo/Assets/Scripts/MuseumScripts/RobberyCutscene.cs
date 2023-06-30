using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class RobberyCutscene : MonoBehaviour
{
    private Movement scriptToDeactivate;
    private TimelineManager timelineManager;
    public GameObject director;
    public GameObject player;
    
    public bool isInRange = false;
    public bool isTriggered = false;

    public AudioSource museumBGM;
    public AudioSource nemyBGM;

    void Update()
    {
        if(isInRange) 
        {        
            player.GetComponent<Movement>().enabled = false;
            director.GetComponent<TimelineManager>().enabled = true;  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;        
            museumBGM.Stop();
            nemyBGM.Play();
        }      
  
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player")) 
            isInRange = false;            
    }
}
