using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public static string[] textDefinitions = {
        "La propiedad intelectual es tener derechos sobre nuestras ideas y creaciones. Protege lo que creamos y nos asegura que nadie pueda copiar o usar nuestras creaciones sin permiso.",
        "La propiedad industrial protege invenciones y creaciones comerciales, como marcas comerciales y patentes. Las marcas comerciales protegen los nombres y logotipos, y las patentes protegen las invenciones útiles y nuevas.",
        "El derecho de autor protege obras artísticas y literarias, como canciones, libros y pinturas. Nos da el derecho exclusivo sobre nuestras creaciones y evita que otros las copien o usen sin permiso.",
        "Las patentes protegen nuestras invenciones útiles y nuevas. Nos otorgan el derecho exclusivo de fabricar y vender nuestra invención, evitando que otros se aprovechen de nuestro trabajo.",
        "El registro es el proceso para obtener protección legal de nuestras creaciones. Al registrar nuestras marcas comerciales y obras artísticas, aseguramos que nadie las copie sin permiso y se reconocen como nuestras.",
        "Una vez protegidas, podemos comercializar nuestras invenciones y obras. Esto implica vender nuestras invenciones a empresas interesadas o licenciar nuestros derechos de autor para que otros puedan usar nuestras creaciones a cambio de un pago.",
        "Proteger nuestras creaciones nos asegura reconocimiento y recompensa por nuestro trabajo. Fomenta la creatividad y la innovación en la sociedad al valorar y respetar el esfuerzo de cada individuo."
    };
    private bool isDialogActive = false;

    [SerializeField] private Text count;

    private bool hasInteracted = false;
    private static int textIndex = 0;
    private SpriteRenderer spriteRenderer;

    public Canvas prizeCanvas;
    private Animator winningAnim;
    public GameObject winningObject;
    private bool isAnimationPlaying = false;
    public Image image;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        winningAnim = prizeCanvas.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey) && !isAnimationPlaying)
        {
            if (spriteIndex < sprites.Count)
                ChangeSprite();
            else if (!hasInteracted)
            {
                Debug.Log(spriteRenderer.name);
                image.sprite = spriteRenderer.sprite;
                hasInteracted = true;
                textElement.text = textDefinitions[textIndex];
                player.GetComponent<Movement>().enabled = false;
                winningObject.SetActive(true);
                winningAnim.Play("WinningPrize");
                StartCoroutine(ShowDialogAfterTimeline());
                isAnimationPlaying = true; 
                textIndex++;
            }
            else if (isDialogActive)
            {
                dialogBox.SetActive(false);
                isDialogActive = false;
				if (spriteIndex == sprites.Count)
        		{
            		interactions++;
            		count.text = "Objetos creados: " + interactions + "/8";
        		}
                player.GetComponent<Movement>().enabled = true;
            }
            else
            {
                dialogBox.SetActive(true);
                isDialogActive = true;
            }
        }
    }

    IEnumerator ShowDialogAfterTimeline()
    {
        yield return new WaitForSeconds(5.0f); 
        dialogBox.SetActive(true);
        isDialogActive = true;
        textElement.text = textDefinitions[textIndex];
        winningObject.SetActive(false); 
        isAnimationPlaying = false; 
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



