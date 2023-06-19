using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public GameObject director;
    [SerializeField] public GameObject typingCanvas;
    [SerializeField] public GameObject wordManager;

    //Nemy Max Health
    public int score = 1500;
    public int currentHealth = 1500;

    public AudioSource museumBGM;
    public AudioSource nemyBGM;

    [SerializeField] private NemyHealthBar _healthbar;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {   
        score = 1500;
        currentHealth = score;
        scoreText.gameObject.SetActive(false);

        _healthbar.UpdateHealthBar(score, currentHealth);
        UpdateScoreText();
    }

    public void AddScore()
    {
        currentHealth -= 10;
        UpdateScoreText();

        if (currentHealth <= 0)
        {   
            currentHealth = 0;
            director.GetComponent<TimelineManager>().enabled = true;
            wordManager.GetComponent<WordManager>().enabled = false;
            typingCanvas.SetActive(false);
            nemyBGM.Stop();
            museumBGM.Play();
            Destroy(wordManager);
        }
    }

    public void LoadSceneAfterTimeline()
    {
        Loader.Load(Loader.Scene.CNR);
    }

    void UpdateScoreText()
    {
        _healthbar.UpdateHealthBar(score, currentHealth);
        scoreText.text = "Boss HP: " + currentHealth.ToString();
    }
}