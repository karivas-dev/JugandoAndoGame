using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] punto;
    [SerializeField] private float speed = 6f;

    private int targetWaypointIndex = 0;
    
    private Transform playerTransform;

	[SerializeField] private float additionalSpeed = 80f;

    private void Update()
    {
        if (punto.Length == 0)
            return;

        Vector2 targetPosition = punto[targetWaypointIndex].transform.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetWaypointIndex++;
            if (targetWaypointIndex >= punto.Length)
            {
                targetWaypointIndex = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
            collision.transform.SetParent(this.transform);

			Movement playerMovement = collision.gameObject.GetComponent<Movement>();
			if(playerMovement != null)
			{
				playerMovement.speed += additionalSpeed;
			}
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

			Movement playerMovement = collision.gameObject.GetComponent<Movement>();
			if(playerMovement != null)
			{
				playerMovement.speed -= additionalSpeed;
			}
        }
    }
}