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

    public int score = 1500;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {   
        score = 1500;
        UpdateScoreText();
    }

    public void AddScore()
    {
        score -= 10;
        UpdateScoreText();

        if (score <= 0)
        {   
            score = 0;
            SceneManager.LoadScene("VictoryScreen");
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Boss HP: " + score.ToString();
    }

}