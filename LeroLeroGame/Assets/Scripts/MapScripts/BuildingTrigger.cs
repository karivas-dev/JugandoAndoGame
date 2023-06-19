using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingTrigger : MonoBehaviour
{
    public bool isInRange = false;
    public KeyCode interactKey;
    public int buildingNumber;
    public GameObject canvas;
    public string hint = "No puedes ingresar al bosque, tienes otras cosas que hacer";
    public TMP_Text textElement;
    public GameObject player;

    private bool isHintActive = false;

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                switch (buildingNumber)
                {
                    case 1:
                        Loader.Load(Loader.Scene.CopyRight);
                        break;

                    case 2:
						if(Input.GetKeyDown(interactKey) && isHintActive == false)
						{
						textElement.text = hint;
                        player.GetComponent<PlayerController>().enabled = false;
                        canvas.SetActive(true);
                        isHintActive = true;
						}
						else if (isHintActive && Input.GetKeyDown(interactKey))
        				{
            				CloseHint();
        				}
                        break;

                    case 3:
                        Loader.Load(Loader.Scene.CNR);
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = false;
    }

    public void CloseHint()
    {
        canvas.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        isHintActive = false;
    }
}





