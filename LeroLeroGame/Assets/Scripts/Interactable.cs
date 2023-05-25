using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool isInRange = false;
    public bool isTriggered = false;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject Message;
    public GameObject player;
    public TMP_Text textElement;
    public int number = 0;
    public string definitions;
    private string[] definitionsArray;

    // Start is called before the first frame update
    void Start()
    {
        definitionsArray = definitions.Split(',');
        textElement.text = definitionsArray[number];
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange) 
        {
            if(Input.GetKeyDown(interactKey) && isTriggered == false)
            {
                interactAction.Invoke();
                Message.SetActive(true);
                isTriggered = true;
                /*player.SetActive(false);*/
            }
            else if(Input.GetKeyDown(interactKey) && isTriggered) 
            {
                Message.SetActive(false);
                isTriggered = false;
                /*player.SetActive(true);*/
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
