using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text totalScoreText;
    public Text highscoreText;

    public GameUI gameUIScript;
    public HighscoreScript highscoreScript;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        totalScoreText.text = "Total Score: " + gameUIScript.totalScore.ToString();
        highscoreText.text = "Highscore: " + highscoreScript.highscore.ToString();
    }

    void Update()
    {
        
    }

    public void retry()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("main");
    }
}
