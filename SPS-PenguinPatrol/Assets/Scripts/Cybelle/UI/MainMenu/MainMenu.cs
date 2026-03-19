using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    //scene laoding and saving from https://www.youtube.com/watch?v=faYY3BNmAeA

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button contuineGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button aboutButton;
    [SerializeField] private Button quitButton;


    private void Start()
    {
        DisableButtonsDependingOnData();

    }

    private void DisableButtonsDependingOnData() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            contuineGameButton.interactable = false;
            
        }
    }

    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        Debug.Log("New Game Clicked");
        //creates a new game, which initializes our game data
       DataPersistenceManager.instance.NewGame();
       //SaveGameAndLoadScene();
        //loads game and saves game, because of the code in the data persistance manager
        //SceneManager.LoadSceneAsync("Antarctica");

    }

    public void OnContinueGameClicked()

    {
       
        Debug.Log ("Continue Game Clicked");
        //load next scene, becuase of data persisitance manager simulare to new game
        //addded some player pref stuff so that it only loads a game when is has scene saved.
//        if(PlayerPrefs.GetInt("SavedLoad") == 5)
//        {
//            DisableMenuButtons();
            SaveGameAndLoadScene();
           
//        }
//        else
//        {
//            return;
//        }
//        
    }

      private void SaveGameAndLoadScene() 
    {
        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        // load the scene
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SavedScene"));
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        contuineGameButton.interactable = false;
        settingsButton.interactable = false;
        aboutButton.interactable = false;
        quitButton.interactable = false;

    }
}
