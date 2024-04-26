using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    private Keyboard keyboard;
    public void Awake()
    {
        keyboard = Keyboard.current;
        //Debug.Log("keyboard");
    }
    public void Update()
    {
        if (keyboard != null && keyboard.pKey.wasPressedThisFrame)
        {
            //Debug.Log("pKey pressed");

            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
      {
              pauseMenu.SetActive(false);
              Time.timeScale = 1f;
              isPaused = false;
       }
  void pause()
   {
             pauseMenu.SetActive(true);
             Time.timeScale = 0f;
             isPaused = true;
   }    
}