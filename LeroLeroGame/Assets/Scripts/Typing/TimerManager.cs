using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] public Image image;

    public void UpdateClock(float maxTime, float currentTime) 
    {
        image.fillAmount = currentTime / maxTime;
    }
        
}
