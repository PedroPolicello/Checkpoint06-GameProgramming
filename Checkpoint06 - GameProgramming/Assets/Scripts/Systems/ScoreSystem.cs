using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreNumber;
    private int gameScore = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Another UI instance is active");
            Destroy(gameObject);
        }
        SetupScore();
    }

    void SetupScore()
    {
        scoreText.gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        gameScore += score;
        UpdateScoreText(gameScore);
    }

    public void UpdateScoreText(int updatedScore)
    {
        scoreText.text = updatedScore.ToString();
        scoreNumber.text = updatedScore.ToString();
    }
}
