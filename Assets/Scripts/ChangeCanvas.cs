﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCanvas(string canvasname)
    {
        if (canvasname == "MainMenu")
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
