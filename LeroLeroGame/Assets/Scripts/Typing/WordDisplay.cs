using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fallspeed = 20f;
    public float despawnYPosition = -10f;

    private Word word;
    private WordManager wordManager;

    public void SetWord(Word _word, WordManager _wordManager)
    {
        word = _word;
        wordManager = _wordManager;
        text.text = word.word;
    }
   
    public void RemoveLetter()
    {
        text.text = text.text.Remove(0,1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        wordManager.RemoveWord(word);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, -fallspeed * Time.deltaTime, 0f);
        //checks Y position of the word and destroys the game object if the word reaches -10f 
        if(transform.position.y < despawnYPosition)
        {
            wordManager.RemoveWord(word);
            Destroy(gameObject);
        }
    }

}

