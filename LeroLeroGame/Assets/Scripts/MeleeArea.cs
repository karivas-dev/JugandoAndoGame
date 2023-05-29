using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeArea : MonoBehaviour
{
	[SerializeField] Breakable breakable;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject == breakable.gameObject)
		{
			breakable.HitHandle();
		}
	}
}
