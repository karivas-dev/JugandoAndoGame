using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class MovingTraps : MonoBehaviour {
	[SerializeField] private GameObject[] punto;
	private int indexpunto = 0;
	[SerializeField] private float speed = 4f;

	private void Update()
	{
		if (Vector2.Distance(punto[indexpunto].transform.position, transform.position) < 0.1f)
		{
			indexpunto++;
			if(indexpunto >= punto.Length)
			{
				indexpunto = 0;
			}
		}
		transform.position = Vector2.MoveTowards(transform.position, punto[indexpunto].transform.position, Time.deltaTime * speed);

	}

}