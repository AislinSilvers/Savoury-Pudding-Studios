using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    //[SerializeField] public GameObject gamePanel;
    [SerializeField] public GameObject menuPanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public GameObject aboutPanel;
    [SerializeField] public GameObject quitConfirmationPanel;
    [SerializeField] public GameObject previousPanel;

    [SerializeField] Button startButton;
    [SerializeField] Button settinsButton;
    [SerializeField] Button aboutButton;
    [SerializeField] Button quitButton;           
    [SerializeField] Button yesQuitButton;
    [SerializeField] Button noQuitButton;

    [SerializeField] Button backButton; //close active panel

    public void Start()
    {
        menuPanel.SetActive(true);
    }
    public void LoadGame()
    {
        if (startButton)
        {
            SceneManager.LoadScene(2);
            menuPanel.SetActive(false);
            //gamePanel.SetActive(true);
        }
    }
    public void Settings()
    {
        if (settinsButton)
        {
            settingsPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
        /*  THIS DOESNT WORK!
        if (backButton)
        {
            settingsPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
        */
    }
    public void About()
    {
        if (aboutButton)
        {
            aboutPanel.SetActive(true);
            previousPanel.SetActive(false);
        }

    }
    
    public void QuitConfirmation()
    {        
        if (quitButton)
        {
            quitConfirmationPanel.SetActive(true);   
        }
    }
    public void YesQuit()
    {
        if (yesQuitButton)
        {
            Quit();
        }
    }
    public void NoQuit()
    {
        if(noQuitButton)
        {
            quitConfirmationPanel.SetActive(false);  
        }
    }
    public void Quit()
    {
        // Close the game application
        Application.Quit();
    }
}
