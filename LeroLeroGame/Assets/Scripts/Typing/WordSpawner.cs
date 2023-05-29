using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

     public WordDisplay SpawnWord()
     {
          Vector3 Position = new Vector3(Random.Range(500f, 1200f), 850f);

          GameObject wordObj =  Instantiate(wordPrefab, Position, Quaternion.identity, wordCanvas);
          WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

          return wordDisplay;
     }
     
}
