using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Menu : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public string settingCase;
    
    // Start is called before the first frame update
    public void Play()
    {
        LevelFade.instance.FadeToNextLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);   
        vCam.m_Lens.OrthographicSize = 7;
		vCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = 0.49f;
		vCam.GetCinemachineComponent<CinemachineComposer>().m_ScreenX = 0.51f;
    }
}
