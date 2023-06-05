using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorTrigger : MonoBehaviour
{
    public UnityEvent interactAction;
	public bool isInRange = false;
	public bool isTriggered = false;
	public KeyCode interactKey;
	public GameObject player;
	public GameObject elevator;

    public Transform target;
    public float speed;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (isInRange)
		{
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            
			if (Input.GetKeyDown(interactKey) && isTriggered == false)
			{
				interactAction.Invoke();
				isTriggered = true;
				
			}
			else if (Input.GetKeyDown(interactKey) && isTriggered)
			{
				isTriggered = false;

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
