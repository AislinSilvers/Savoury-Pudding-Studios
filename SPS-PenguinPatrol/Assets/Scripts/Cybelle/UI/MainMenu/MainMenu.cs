using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button contuineGameButton;


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
        //loads game and saves game, because of the code in the data persistance manager
        SceneManager.LoadSceneAsync("Antarctica");
    }

    public void OnContinueGameClicked()

    {
        DisableMenuButtons();
        Debug.Log ("Continue Game Clicked");
        //load next scene, becuase of data persisitance manager simulare to new game
        SceneManager.LoadSceneAsync("Antarctica");
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        contuineGameButton.interactable = false;

    }
}
