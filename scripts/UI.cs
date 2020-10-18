using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/* this is script for UI functions such as score. */
public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject endScreen;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;


    public static UI instance;
    public GameObject pauseScreen;

    void Start()
    {
        UpdateScoreText();
    }

    void Awake()
    {
        instance = this;
    }

    //Up date score:
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    // game status.
    public void SetEndScreen(bool hasWon)
    {
        endScreen.SetActive(true);

        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;
       
        if (hasWon)
        {
            endScreenHeader.text = "You Win";
            endScreenHeader.color = Color.green;
        }
        else
        {
            endScreenHeader.text = "Game Over";
            endScreenHeader.color = Color.red;
        }
    }

    // Restart button
    public void OnRestartButton()
    {
        GameManager.instance.ResetScore();
        //GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(1);
       Time.timeScale = 1.0f;

    }

    // |Menu Button
    public void OnMenuButton()
    {
        if (GameManager.instance.paused)
            GameManager.instance.TogglePauseGame();
        SceneManager.LoadScene(0);
    }
     // Pause command
    public void TogglePauseScreen(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    // Resume command
    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }

    
}
