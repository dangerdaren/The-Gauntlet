using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }
    private bool gameStarted = false;

    HighScore highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = FindObjectOfType<HighScore>();
        menu.SetActive(false);
        StartCoroutine (AllowPause());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            menu.SetActive(isPaused);
        }
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator AllowPause()
    {
        yield return new WaitForSeconds(3);
        gameStarted = true;
    }

    public void RestartLevel()
    {
        Scene currentLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentLevel.buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        highScore.SaveHighScore();
        Application.Quit();
    }
}
