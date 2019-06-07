using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static float score;

    public Text MainScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject PauseUI;
    public GameObject GameOverUI;

    public static bool isGamePaused;
    public static bool isGameOver;

    private void Start()
    {
        score = 0f;
        isGamePaused = false;
        isGameOver = false;

        highScoreText.text = PlayerPrefs.GetFloat("HighScore",0).ToString();
    }

    private void Update()
    {
        Scoring();
        checkIfPaused();
        GameOver();
    }

    public void Scoring()
    {
        MainScore.text = score.ToString();
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            highScoreText.text = score.ToString();
            PlayerPrefs.SetFloat("HighScore", score);
        }
    }

    public void checkIfPaused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            StartCoroutine(WaitForTime(1f));
        }
    }

    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }
}
