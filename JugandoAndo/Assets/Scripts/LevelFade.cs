using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public static LevelFade instance;

    private void Awake() 
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
       levelToLoad = levelIndex;
       animator.SetTrigger("FadeOut"); 
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
