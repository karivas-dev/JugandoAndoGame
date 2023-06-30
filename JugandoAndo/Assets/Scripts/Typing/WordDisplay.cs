using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fallspeed = 20f;
    private Word word;
    private WordManager wordManager;
    private BoxCollider2D boxCollider;
    private float despawnYPositionScreenSpace;

    private void Start()
    {
        FindBoxBG();
        CalculateDespawnYPosition();
    }

    public void SetWord(Word _word, WordManager _wordManager)
    {
        word = _word;
        wordManager = _wordManager;
        text.text = word.word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        wordManager.RemoveWord(word);
        Destroy(gameObject);
    }

    private void Update()
    {
        float despawnYPositionWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(0f, despawnYPositionScreenSpace, 0f)).y;

        if (transform.position.y < despawnYPositionWorldSpace)
        {
            wordManager.RemoveWord(word);
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(0f, -fallspeed * Time.deltaTime, 0f);
        }
    }

    private void FindBoxBG()
    {
        GameObject boxBGObject = GameObject.FindGameObjectWithTag("BoxBG");
        if (boxBGObject != null)
        {
            boxCollider = boxBGObject.GetComponent<BoxCollider2D>();
        }
    }

    private void CalculateDespawnYPosition()
    {
        Vector3 despawnYPositionWorldSpace = boxCollider.bounds.min;
        despawnYPositionScreenSpace = Camera.main.WorldToScreenPoint(despawnYPositionWorldSpace).y;
    }
}

























