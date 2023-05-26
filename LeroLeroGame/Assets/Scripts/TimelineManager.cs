using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private PlayableDirector director;
    public WordTimer wordTimer;
    public CountDown countdown;
    
    void Start() {
        director = GetComponent<PlayableDirector>();
        director.Play();

        StartCoroutine(EnableScriptsAfterTimeline());
    }

    IEnumerator EnableScriptsAfterTimeline()
    {
        yield return new WaitForSeconds((float)director.duration); // Espera hasta que termine la línea de tiempo

        wordTimer.isActive = true; // Activa el WordTimer
        countdown.isActive = true; // Activa el CountDown
    }
}
