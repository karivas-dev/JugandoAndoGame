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

    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        if (isInRange && !isMoving)
        {
            if (Input.GetKeyDown(interactKey) && isTriggered == false)
            {
                isTriggered = true;
                MoveElevator();
            }
            else if (Input.GetKeyDown(interactKey) && isTriggered)
            {
                isTriggered = false;
                MoveElevator();
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

    void MoveElevator()
    {
        isMoving = true;
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        Vector3 startPosition = elevator.transform.position;
        Vector3 targetPosition = target.position;
        float elapsedTime = 0f;

        while (elapsedTime < speed)
        {
            elevator.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / speed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elevator.transform.position = targetPosition;
        interactAction.Invoke();

        isMoving = false;
    }
}
