using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    public bool isActive = false;

    public float wordDelay = 4f;
    private float nextTime = 0f;

    private void Update()
    {
        if (!isActive) return;

        if(Time.time >= nextTime)
        {
            wordManager.AddWord();
            nextTime = Time.time + wordDelay;
            wordDelay *= 1f;
        }
    }
}
