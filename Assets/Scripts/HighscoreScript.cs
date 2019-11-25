using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreScript : MonoBehaviour
{
    public GameUI gameUIScript;

    public float highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
    }

    void Update()
    {
        if (gameUIScript.totalScore > highscore)
        {
            highscore = gameUIScript.totalScore;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
    }
}
