using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    public bool isInRange = false;
    public KeyCode interactKey;
    public int buildingNumber;

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                LoadLevel(buildingNumber);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = false;
    }

    private void LoadLevel(int level)
    {
        if (PlayerPrefs.GetInt("BuildingNumber") >= level)
        {
            switch (level)
            {
                case 1:
                    Loader.Load(Loader.Scene.CopyRight);
                    break;
                case 2:
                    Loader.Load(Loader.Scene.IndustrialProperty);
                    break;
                // Agrega más casos para niveles adicionales según sea necesario
            }
        }
        else
        {
            Debug.Log("No puedes acceder a este nivel todavía");
        }
    }
}




















