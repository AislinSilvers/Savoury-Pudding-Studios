using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject gamePanel;
    [SerializeField] public GameObject menuPanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public GameObject aboutPanel;
    [SerializeField] public GameObject quitConfirmationPanel;
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject saveLoadsPanel;
    [SerializeField] public GameObject mapPanel;
    [SerializeField] public GameObject accessoriesPanel;
    [SerializeField] Button startButton;
    [SerializeField] Button settinsButton;
    [SerializeField] Button aboutButton;
    [SerializeField] Button quitButton;           // Button for quitting the game
    [SerializeField] Button yesQuitButton;
    [SerializeField] Button noQuitButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button saveSlotsButton;
    [SerializeField] Button mapButton;
    [SerializeField] Button accessoriesButton;


    public void Start()
    {
        menuPanel.SetActive(true);
    }
    public void LoadGame()
    {
        if (startButton)
        {
            gamePanel.SetActive(true);
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
    public void Pause()
    {
        if (pauseButton)
        {
            pausePanel.SetActive(true);
        }
    }
    public void SaveSlots()
    {
        if (saveSlotsButton)
        {
            saveLoadsPanel.SetActive(true);
        }
    }
    public void Map()
    {
        if (mapButton)
        {
            mapPanel.SetActive(true);
        }   
    }
    public void Accessories()
    {
        if (accessoriesButton)
        {
            accessoriesPanel.SetActive(true);
        }
    }
}
