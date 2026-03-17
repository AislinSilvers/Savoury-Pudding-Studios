using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
    public GameData data;
    public PlayerRespawn respawn;
    //public Spawnplayer playerPosData;

    public void Start()
    {
        gameMenu.SetActive(true);
        save = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
        respawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
        pause = GetComponent<PauseMenu>();
        //playerPosData = FindObjectOfType<Spawnplayer>();
    }
    public void Hint()
    {
        if (hintButton || Input.GetButtonDown("Help"))
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
            //cybelle added stuff, kept the jason file save location and prefs scenes since i dont know how to save scenes in jason
            //it sometimes works, usally dosent save player position and load form beggining but at least it saves what level you are on.
            //data.playerPosition = respawn.respawnPoint;
            //playerPosData.PlayerPosSave(); //this was for the second attemp, it did not work and i dont like how the code is writen
            PlayerPrefs.SetInt("SavedScene",SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("SavedLoad", 5);
            save.SaveGame();
            //not cybelles line of code, below this
            SceneManager.LoadScene(0);
            
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
