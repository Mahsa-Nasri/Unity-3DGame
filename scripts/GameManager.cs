using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score=0;
    public static GameManager instance;
    public bool paused;

    // Reset the score here.
    public void ResetScore()
    {
        score = 0;
        UI.instance.UpdateScoreText();
    }
    void Awake()
    {
       
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Add score here
     public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
        UI.instance.UpdateScoreText();

    }

    // end of level and player wins:
    public void LevelEnd()
    {
        // is this the last level?
        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            // display the win screen
            WinGame();

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void WinGame()
    {

        UI.instance.SetEndScreen(true);
        //Time.timeScale = 0.0f;

    }

    public void GameOver()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UI.instance.SetEndScreen(false);
        //Time.timeScale = 0.0f;
    }

    public void TogglePauseGame()
    {
        paused = !paused;

        if (paused)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;

        UI.instance.TogglePauseScreen(paused);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }
}
