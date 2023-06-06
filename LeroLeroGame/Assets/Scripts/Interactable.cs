using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactAction;
    public KeyCode interactKey;
    public GameObject dialogBox;

    public List<Sprite> sprites = new List<Sprite>();

    private bool isInRange = false;
    private int spriteIndex = 0;

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
            {
                ChangeSprite();
            }
            else
            {
                isInRange = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = sprites[spriteIndex];
        spriteIndex++;
        interactAction.Invoke();
        dialogBox.SetActive(true);
    }
}




