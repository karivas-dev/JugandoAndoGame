using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
	public bool isInRange = false;
	public KeyCode interactKey;
    public int buildingNumber;

	void Update()
	{
		if (isInRange)
		{
			if (Input.GetKeyDown(interactKey))
			{
				switch(buildingNumber)
                {
                    case 1:
                        Loader.Load(Loader.Scene.CopyRight);
                        break;

                    case 2:
						Debug.Log("Aun no puedes acceder a este nivel");
						break;

                    case 3:
						
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
}
