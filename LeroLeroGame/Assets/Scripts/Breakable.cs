using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Breakable : MonoBehaviour
{
    [SerializeField] Sprite[] hitSprite;
	
	[SerializeField] int timesHit;

	void Update()
	{
		
	}

	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CUALQUIER COSA ENTRE COMILLAS");
		if (tag == "Breakable")
			{
            Debug.Log("CUALQUIER COSA sin COMILLAS");
				HitHandle();

			}

    }

    public void HitHandle()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
		else
		{
			ShowNextSprite();
		}

	}
    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex]!=null)
        {
            GetComponent<SpriteRenderer>().sprite= hitSprite[spriteIndex];
        }
        else
        {
            Debug.Log("error finding sprites");
        }
    }
}

        
	

