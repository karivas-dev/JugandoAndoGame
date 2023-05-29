using System.Collections.Generic;
using UnityEngine.Playables;
using System.Collections;
using UnityEngine;
using Cinemachine;

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
        yield return new WaitForSeconds((float)director.duration); 

        wordTimer.isActive = true; 
        countdown.isActive = true;

    }
}
