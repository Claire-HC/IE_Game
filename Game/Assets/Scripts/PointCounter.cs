using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text totalScoreText;
    public int option;

    // Start is called before the first frame update
    void Start()
    {
        if(option == 1)
        {
            score = 60;
        }
        else if(option == 2)
        {
            score = 40;
        }
        else if(option == 3)
        {
            score = 20;
        }
        UpdateScore();
    }

    private void Update()
    {
        TotalPoint();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetTotalScore()
    {
        return score;
    }

    void TotalPoint()
    {
        totalScoreText.text = "Score: " + score;
    }
}
