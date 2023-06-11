using UnityEngine;
using UnityEngine.SceneManagement;

public class Prueba : MonoBehaviour
{
    public KeyCode finishKey = KeyCode.V;
    public string worldmapScene = "MapWorld";

    private bool isLevelFinished = false;

    void Update()
    {
        if (isLevelFinished)
        {
            if (Input.GetKeyDown(finishKey))
            {
                ReturnToWorldmap();
            }
        }
        else
        {
            if (Input.GetKeyDown(finishKey))
            {
                FinishLevel();
            }
        }
    }

    void FinishLevel()
    {
        Debug.Log("¡Nivel completado!");

        isLevelFinished = true;
        GameInitializer.Instance.CompleteCopyRight();
    }

    void ReturnToWorldmap()
    {
        SceneManager.LoadScene(worldmapScene);
    }
}
















