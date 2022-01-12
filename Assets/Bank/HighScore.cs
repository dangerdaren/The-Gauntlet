using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    int highScore = 0;
    TMP_Text highScoreText;
    int savedHighScore;
    Bank bank;


    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
        LoadHighScore();
        highScoreText = GetComponent<TMP_Text>();
        highScoreText.text = $"Record: {highScore}";

        if (PlayerPrefs.GetInt("NewPlayer") == 1)
        {
            LoadHighScore();
        }
        //else
        //{
        //    ResetHighScore();
        //}

    }

    public void RecordHighScore(int currentBalance)
    {
        if (currentBalance > highScore)
        {
            highScore = currentBalance;
            highScoreText.text = $"Record: {highScore}";
            SaveHighScore();
        }
    }

    public void ResetHighScore()
    {
        highScore = 0;
        highScoreText.text = $"Record: {highScore}";
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void LoadHighScore()
    {
        if (PlayerPrefs.GetInt("NewPlayer") == 1 && PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }
    }

}
