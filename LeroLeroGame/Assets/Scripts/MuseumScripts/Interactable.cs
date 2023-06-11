using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
	public KeyCode interactKey;
	public TMP_Text textElement;
	public GameObject dialogBox;
	public GameObject player;
	public List<Sprite> sprites = new List<Sprite>();
	private bool isInRange = false;
	private int spriteIndex = 0;
	public string[] textDefinitions = {"s",
	"d",
	"NO","jaj", "r", 
	};
	private bool isDialogActive = false;


	private bool hasInteracted = false;
	private bool dialogIn = false;
	private static int textIndex = 0;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if (isInRange && Input.GetKeyDown(interactKey))
		{
			if (spriteIndex < sprites.Count)
				ChangeSprite();
			else if (!hasInteracted)
			{
				hasInteracted = true;
				textElement.text = textDefinitions[textIndex];
				player.GetComponent<Movement>().enabled = false;
				dialogBox.SetActive(true);
				isDialogActive = true;
			}
			else if (isDialogActive)
			{
				dialogBox.SetActive(false);
				isDialogActive = false;
				player.GetComponent<Movement>().enabled = true;
			}
			else
			{
				dialogBox.SetActive(true);
				isDialogActive = true;
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

	private void ChangeSprite()
	{
		spriteRenderer.sprite = sprites[spriteIndex];
		spriteIndex++;
	}
}

