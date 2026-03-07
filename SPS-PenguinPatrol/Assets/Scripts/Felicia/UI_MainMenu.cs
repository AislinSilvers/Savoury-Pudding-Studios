using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    //panels/canvases on main menu screen (scene 1)
    [SerializeField] public GameObject savesPanel;
    [SerializeField] public GameObject menuPanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public GameObject aboutPanel;
    [SerializeField] public GameObject quitConfirmationPanel;

    //buttons on main menu screen (scene 1)
    [SerializeField] Button startButton;
    [SerializeField] Button settinsButton;
    [SerializeField] Button aboutButton;
    [SerializeField] Button savesButton;
    [SerializeField] Button quitButton;           
    [SerializeField] Button yesQuitButton;
    [SerializeField] Button noQuitButton;


    public void Start()
    {
        menuPanel.SetActive(true);  //auto activate main menu panel
    }
    public void StartGame()
    {
        if (startButton)
        {
            SceneManager.LoadScene(2);  //on start load antarctica
            //menuPanel.SetActive(false);
        }
    }
    public void LoadSaves()
    {
        if (savesButton)
        {
            savesPanel.SetActive(true);
        }
    }
    public void Settings()
    {
        if (settinsButton)
        {
            settingsPanel.SetActive(true);  
        }
    }
    public void About()
    {
        if (aboutButton)
        {
            aboutPanel.SetActive(true);
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
            Application.Quit(); //close application after confirming on conf screen
        }
    }
    public void NoQuit()
    {
        if (noQuitButton)
        {
            quitConfirmationPanel.SetActive(false);  
        }
    }
}
