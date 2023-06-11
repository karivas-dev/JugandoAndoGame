using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public static GameInitializer Instance { get; private set; }

    private const string BuildingNumberKey = "BuildingNumber";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey(BuildingNumberKey))
        {
            PlayerPrefs.SetInt(BuildingNumberKey, 1);
            PlayerPrefs.Save();
        }
    }

    public void CompleteCopyRight()
    {
        PlayerPrefs.SetInt(BuildingNumberKey, 2);
        PlayerPrefs.Save();
    }

    public int GetBuildingNumber()
    {
        return PlayerPrefs.GetInt(BuildingNumberKey);
    }

    public void ResetBuildingNumber()
    {
        PlayerPrefs.SetInt(BuildingNumberKey, 1);
        PlayerPrefs.Save();
    }
}















