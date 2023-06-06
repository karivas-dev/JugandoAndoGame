using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingTrigger : MonoBehaviour
{
    public UnityEvent interactAction;
	public bool isInRange = false;
	public bool isTriggered = false;
	public KeyCode interactKey;
	public GameObject player;
    public int buildingNumber;

	// Start is called before the first frame update
	void Start()
	{
	
	}

	// Update is called once per frame
	void Update()
	{
        Debug.Log(isInRange);
		if (isInRange)
		{
			if (Input.GetKeyDown(interactKey) && isTriggered == false)
			{
				switch(buildingNumber)
                {
                    case 1:
                        Loader.Load(Loader.Scene.CopyRight);
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;
                }
			}
			else if (Input.GetKeyDown(interactKey) && isTriggered)
			{

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
}
