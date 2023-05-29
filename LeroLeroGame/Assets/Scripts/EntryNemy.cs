using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EntryNemy : MonoBehaviour
{
    private PlayerPlatformerController scriptToDeactivate;
    private TimelineManager timelineManager;
    public GameObject canvas;
    public GameObject director;
    public Animator animator;
    public GameObject player;
    public KeyCode interactKey;
    public GameObject letterHint;


    public UnityEvent interactAction;
    public bool isInRange = false;
    public bool isTriggered = false;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        animator.SetBool("idle", false);
    }

    void Update()
    {
        if(isInRange) 
        {
            if(Input.GetKeyDown(interactKey) && isTriggered == false)
            {
                player.GetComponent<PlayerPlatformerController>().enabled = false;
                letterHint.SetActive(false);
                interactAction.Invoke();
                canvas.SetActive(true);
                isTriggered = true;
            }
            else if(Input.GetKeyDown(interactKey) && isTriggered) 
            {
                if (spriteRenderer.flipX)        
                    spriteRenderer.flipX = !spriteRenderer.flipX;
        
                canvas.SetActive(false);
                animator.SetBool("idle", true);
                director.GetComponent<TimelineManager>().enabled = true;
                isTriggered = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))      
            isInRange = true;        
  
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player")) 
            isInRange = false;            
    }

   /* private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))  
        {
            player.GetComponent<PlayerPlatformerController>().enabled = false;       
            director.GetComponent<TimelineManager>().enabled = true;
            elementToDeactivate.SetActive(false);
            animator.SetBool("idle", true);
            healthBar.SetActive(true);
            screenBG.SetActive(true);
            timer.SetActive(true);
        }   
    }*/
}
