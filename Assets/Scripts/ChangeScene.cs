using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
