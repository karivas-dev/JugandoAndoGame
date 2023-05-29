using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactAction;
    public bool isInRange = false;
    public bool isTriggered = false;
    public KeyCode interactKey;
    public GameObject dialogBox;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange) 
        {
            if(Input.GetKeyDown(interactKey) && isTriggered == false)
            {
                interactAction.Invoke();
                dialogBox.SetActive(true);
                isTriggered = true;
            }
            else if(Input.GetKeyDown(interactKey) && isTriggered) 
            {
                dialogBox.SetActive(false);
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
}
