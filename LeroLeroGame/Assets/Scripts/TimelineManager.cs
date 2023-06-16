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
    public EntryNemy entry;
    public string cutscene;
    
    void Start() {
        director = GetComponent<PlayableDirector>();
        director.Play();

        StartCoroutine(EnableAfterTimeline());
    }

    IEnumerator EnableAfterTimeline()
    {
        yield return new WaitForSeconds((float)director.duration); 
        switch(cutscene) 
        {
            case "EntryNemy":
                wordTimer.isActive = true; 
                countdown.isActive = true;
                entry.isInRange = false;
                break;

            case "Robbery":
                Loader.Load(Loader.Scene.IndustrialProperty);
                break;
            
            case "WinningNemy":
                
                break;
        }
    }
}
