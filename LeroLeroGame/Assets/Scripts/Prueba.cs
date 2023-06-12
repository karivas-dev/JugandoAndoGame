using UnityEngine;
using UnityEngine.SceneManagement;

public class Prueba : MonoBehaviour
{
    public KeyCode finishKey = KeyCode.V;
    public KeyCode finishKey2 = KeyCode.C;
    public string Scene = "IndustrialProperty";

    private bool isLevelFinished = false;

    void Update()
    {
        if (isLevelFinished)
        {
            if (Input.GetKeyDown(finishKey))
            {
                ReturnToWorldmap();
            }
            else if(Input.GetKeyDown(finishKey2))
            {
                ReturnToWorldmap2();
            }
        }
        else
        {
            if (Input.GetKeyDown(finishKey))
            {
                FinishLevel();
            }
            else if (Input.GetKeyDown(finishKey2))
            {
                FinishLevel();
            }
        }
    }

    void FinishLevel()
    {
        Debug.Log("¡Nivel completado!");

        isLevelFinished = true;
    }

    void ReturnToWorldmap()
    {
        Loader.Load(Loader.Scene.IndustrialProperty);
    }

    void ReturnToWorldmap2()
    {
        Loader.Load(Loader.Scene.MapWorld2);
    }
}

