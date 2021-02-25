using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene("1F Scene");
        Time.timeScale = 1f;
        ScoreManager.resetScore();
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
        ScoreManager.resetScore();
    }
}
