using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void NormalButton()
    {
        SceneManager.LoadScene("1F Scene");
        Time.timeScale = 1f;
        ScoreManager.resetScore();
        LevelManager.setNormal();
    }

    public void ExpertButton()
    {
        SceneManager.LoadScene("1F Scene");
        Time.timeScale = 1f;
        ScoreManager.resetScore();
        LevelManager.setExpert();
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("1F Scene");
        Time.timeScale = 1f;
        ScoreManager.resetScore();
        if(LevelManager.getLevel() == 0)
        {
            LevelManager.setNormal();
        }
        else
        {
            LevelManager.setExpert();
        }
        
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
        ScoreManager.resetScore();
    }
}
