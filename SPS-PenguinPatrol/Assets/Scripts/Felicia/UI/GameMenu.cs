using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] public GameObject gameMenu;
    [SerializeField] public GameObject pauseMenu;
    //[SerializeField] public GameObject saveMenu;
    [SerializeField] public GameObject hintMenu;
    [SerializeField] public GameObject mapMenu;
    [SerializeField] public GameObject inventoryMenu;
    [SerializeField] public GameObject settingsMenu;

    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button hintButton;
    [SerializeField] Button closeHintButton;
    [SerializeField] Button savesButton;
    [SerializeField] Button mapButton;
    [SerializeField] Button inventoryButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button backToMainButton;

    //cybelle added some data stuff to make sure it saves game on back to menu
   
    public DataPersistenceManager save;
    public PauseMenu pause;

    public void Start()
    {
        gameMenu.SetActive(true);
        save = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        pause = GetComponent<PauseMenu>();
    }
    public void Hint()
    {
        if (hintButton)
        {
            hintMenu.SetActive(true);
        }
    }
    public void CloseHint()
    {
        if (closeHintButton)
        {
            hintMenu.SetActive(false);
        }
    }
    public void Pause()
    {
        if (pauseButton)
        {
            pauseMenu.SetActive(true);
            gameMenu.SetActive(false);
        } 
    }
    /*public void OpenSaves()
    {
        if (savesButton)
        {
            saveMenu.SetActive(true);
        }
    }*/
    public void OpenMap()
    {
        if (mapButton)
        {
            mapMenu.SetActive(true);
        }
    }
    public void OpenInventory()
    {
        if (inventoryButton)
        {
            inventoryMenu.SetActive(true);
        }
    }
    public void OpenSettings()
    {
        if (settingsButton)
        {
            settingsMenu.SetActive(true);
        }
    }
    public void BackToMainMenu()
    {
        if (backToMainButton)
        {
            save.SaveGame();
            PlayerPrefs.SetInt("SavedScene",SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(1);
            
        }
    }
    public void Resume()
    {
        if (resumeButton)
        {
            pauseMenu.SetActive(false);
            pause.isPaused = false; 
            Time.timeScale = 1;
            AudioListener.pause = false;
            gameMenu.SetActive(true);
        }
    }
}
