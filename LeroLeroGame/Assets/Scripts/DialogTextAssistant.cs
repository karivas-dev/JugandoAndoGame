using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogTextAssistant : MonoBehaviour
{
    public TMP_Text textElement;
    public bool invisibleCharacters;
    public float timePerCharacter;
    public string text;
    private int characterIndex = 0;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        textElement.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if (textElement != null) {
            timer -= Time.deltaTime;
            while (timer <= 0f) {
                timer += timePerCharacter;
                characterIndex++;
                string textIn = text.Substring(0, characterIndex);
                if(invisibleCharacters) 
                    textIn += "<color=#00000000>" + text.Substring(characterIndex) + "</color>";

                textElement.text = textIn;

                if(characterIndex >= text.Length) 
                {
                    textElement = null;
                    return;
                }
            }
        }
    }

    public void Writter() {

    }
}
