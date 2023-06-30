using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private GameObject attackarea = default;

    private float timetoAttack = 0.25f;
    private float timer = 0f;
    private bool attacking = false;
	// Update is called once per frame
	void Start()
	{
        attackarea = transform.GetChild(0).gameObject;
	}

	void Update()
    {
      if (Input.GetMouseButtonDown(0))
		{
			Attack();
		}
		if (attacking)
		{
			timer += Time.deltaTime;

			if(timer >= timetoAttack)
			{
				timer = 0;
				attacking = false;
				attackarea.SetActive(attacking);
			}
		}
    }
	private void Attack()
	{
		attacking= true; 
		attackarea.SetActive(attacking);
	}
}
