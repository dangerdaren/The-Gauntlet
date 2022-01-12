using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance; //todo remove S.F. later.
    public int CurrentBalance { get { return currentBalance; } }

    Gold gold;
    HighScore highScore;

    private void Start()
    {
        gold = FindObjectOfType<Gold>();
        highScore = FindObjectOfType<HighScore>();
        currentBalance = startingBalance;
        gold.IncreaseGold(currentBalance);
    }


    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        gold.IncreaseGold(amount);
        highScore.RecordHighScore(currentBalance);
    }

    public void Withdrawl(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        gold.DecreaseGold(amount);

        if (currentBalance < 0)
        {
            highScore.SaveHighScore();
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        Scene currentLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLevel.buildIndex);
    }
   
}
