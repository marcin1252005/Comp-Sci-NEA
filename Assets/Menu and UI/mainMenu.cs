using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//scene management contains classes related to scene management

public class mainMenu : MonoBehaviour
{
    public void nextScene()
    //function will load next scene index
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //will load scene by getting the current active scene's index
        //and incrementing it by one
    }
    public void prevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void ExitGame()
    {
        Debug.Log("Quit Selected");
        Application.Quit();
    }
}