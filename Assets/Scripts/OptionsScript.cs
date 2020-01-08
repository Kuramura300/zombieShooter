using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public Text highscoreText;
    private float highscore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highscore = PlayerPrefs.GetFloat("highscore");

        highscoreText.text = "Reset Highscore (" + highscore + ")";
    }

    public void resetHighscore()
    {
        PlayerPrefs.SetFloat("highscore", 0);
    }
}
