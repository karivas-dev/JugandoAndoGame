using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteEnabler : MonoBehaviour
{
	List<string> completedElements = new List<string>();
	public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
	public List<Image> imageComponents = new List<Image>();
	private void Awake()
	{
		LoadInteractions();
		// Otro código de inicialización
	}

	private void Start()
	{
		foreach (var element in completedElements)
		{
			// Find the GameObject with the corresponding name
			GameObject elementObject = GameObject.Find(element);

			// Check if the GameObject exists
			if (elementObject != null)
			{
				// Get the SpriteRenderer component of the GameObject
				SpriteRenderer spriteRenderer = elementObject.GetComponent<SpriteRenderer>();
				Image image = elementObject.GetComponent<Image>();
				// Check if the SpriteRenderer component exists
				if (spriteRenderer != null)
				{
					// Enable the sprite renderer
					spriteRenderer.enabled = true;
					image.enabled = true;
					Debug.Log("Element: " + element + ", SpriteRenderer Enabled");
				}
				else
				{
					Debug.Log("SpriteRenderer component not found for element: " + element);
				}
			}
			else
			{
				Debug.Log("Element GameObject not found: " + element);
			}
		}
	}






	private void LoadInteractions()
	{
		string interactionString = PlayerPrefs.GetString("Interactions", "");
		string[] interactionArray = interactionString.Split(',');
		completedElements = new List<string>(interactionArray);
	}
}