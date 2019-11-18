using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;

    public GameObject pauseMenu;
    public GameObject shopMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (paused == false)
        {
            pauseMenu.SetActive(true);

            Time.timeScale = 0;

            paused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            shopMenu.SetActive(false);

            Time.timeScale = 1;

            paused = false;
        }
    }
}
