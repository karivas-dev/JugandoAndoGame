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

    //Nemy Max Health
    public int score = 1500;
    public int currentHealth = 1500;

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
            //SceneManager.LoadScene("MapWorld2");
        }
    }

    void UpdateScoreText()
    {
        _healthbar.UpdateHealthBar(score, currentHealth);
        scoreText.text = "Boss HP: " + currentHealth.ToString();
    }

}