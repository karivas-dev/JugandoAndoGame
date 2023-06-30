using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VcamSettings : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public string settingCase;
    public CinemachineConfiner confiner;
    public PolygonCollider2D confinerShape;

    // Start is called before the first frame update
    void Awake()
    {
        switch(settingCase) 
        {
            case "MapWorld":
                confiner.m_BoundingShape2D = confinerShape;
                vCam.m_Lens.OrthographicSize = 15;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
                break; 
            case "Museum":
                confiner.m_BoundingShape2D = confinerShape;
                vCam.m_Lens.OrthographicSize = 15;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.3f;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.6f;
                break;
            case "IP":
                confiner.m_BoundingShape2D = confinerShape;
                vCam.m_Lens.OrthographicSize = 7;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
                break;
            case "CNR":
                confiner.m_BoundingShape2D = confinerShape;
                vCam.m_Lens.OrthographicSize = (float)22.5;
                vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;
				vCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
                break;
        }
    }
}
