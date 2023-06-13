using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
	private static int interactions = 0;
	public KeyCode interactKey;
	public TMP_Text textElement;
	public GameObject dialogBox;
	public GameObject player;
	public List<Sprite> sprites = new List<Sprite>();
	private bool isInRange = false;
	private int spriteIndex = 0;
	public static string[] textDefinitions = {"�Mira lo que has creado! Es una hermosa pintura de un paisaje. Al crear esta obra, est�s ejerciendo tu derecho de autor, que te protege como el creador original de esta pintura. Esto significa que nadie puede copiarla o usarla sin tu permiso.",
	"�Incre�ble! Has creado una pintura abstracta. Al expresar tus ideas y emociones a trav�s de esta obra, est�s demostrando tu propiedad intelectual. Esto significa que tienes derechos exclusivos sobre esta creaci�n art�stica y puedes decidir c�mo compartirla y protegerla.",
	" �Vaya! Has creado un retrato muy realista. Esta obra de arte est� protegida por los derechos de autor. Esto significa que nadie puede copiarla o vender reproducciones sin tu autorizaci�n. Eres el due�o de esta creaci�n y puedes decidir c�mo se utiliza.",
	"�Genial! Has creado una pintura de un animal. Al hacerlo, est�s mostrando tu talento art�stico y tus habilidades creativas. Recuerda que esta pintura est� protegida por los derechos de autor, lo que te da el poder de decidir c�mo se utiliza y qui�n puede beneficiarse de ella.",
	"�Fascinante! Has creado una escultura abstracta. Al ser el creador de esta obra, tienes derechos de propiedad intelectual sobre ella. Esto significa que puedes decidir c�mo se comparte, se exhibe y se protege. Tu creatividad es valiosa y debes asegurarte de que se respete.",
	"�Asombroso! Has creado un plano industrial de una f�brica. Este plano es parte de la propiedad industrial, que se refiere a los derechos sobre invenciones y creaciones relacionadas con la industria y el comercio. Al dise�ar este plano, est�s mostrando tu talento para desarrollar ideas pr�cticas y eficientes.",
	"�Mira lo que hiciste! Has creado una escultura de una figura humana. Al crear esta obra de arte, est�s ejerciendo tu propiedad intelectual. Puedes registrar esta escultura para obtener una protecci�n adicional y asegurarte de que nadie pueda copiarla o utilizarla sin tu permiso."
  };
	private bool isDialogActive = false;

	[SerializeField]private  Text count;

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
				textIndex++;
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

		if (spriteIndex == sprites.Count)
		{
			interactions++;
			count.text = "Objetos creados: " + interactions + "/8";
		}
	}
}


