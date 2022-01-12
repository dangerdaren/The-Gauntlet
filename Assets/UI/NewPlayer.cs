using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewPlayer : MonoBehaviour
{
    [SerializeField] GameObject rules;
    [SerializeField] GameObject buttons;
    [SerializeField] TMP_Text highScore;
    bool showRules = false;

    private void Start()
    {

        if (PlayerPrefs.HasKey("HighScore") == true)
        {
            highScore.text = $"High Score: {PlayerPrefs.GetInt("HighScore")}";
        }
    }

    public void FreshStart()
    {
        PlayerPrefs.SetInt("NewPlayer", 0);
        SceneManager.LoadScene(1);
    }

    public void ReturningPlayer()
    {
        PlayerPrefs.SetInt("NewPlayer", 1);
        SceneManager.LoadScene(1);
    }

    public void ShowRules()
    {
        showRules = !showRules;
        buttons.SetActive(!showRules);
        rules.SetActive(showRules);
        
    }
}
