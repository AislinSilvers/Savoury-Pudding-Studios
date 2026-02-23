using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
      public static bool gameIsPaused;
      public GameObject objectToToggle;
    [SerializeField] 
    private InputActionReference press;
 void Awake()
    {
        gameIsPaused = false; 
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    
    void Update()
    { 

    press.action.performed += context => objectToToggle.SetActive(! objectToToggle.activeSelf);
       press.action.performed += context => gameIsPaused = !gameIsPaused;
       press.action.performed += context => PauseGame();
        
    }
   

    void PauseGame ()
    {

        
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
             //AudioListener.pause = true;
        }
        
        else
        {
            Time.timeScale = 1;
           AudioListener.pause = false;
        }
    }
}
