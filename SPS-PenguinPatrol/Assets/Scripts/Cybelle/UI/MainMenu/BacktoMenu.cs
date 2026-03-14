using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BacktoMenu : MonoBehaviour
{
    
    public DataPersistenceManager save;

    public void Start()
    {
        
        save = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();
    }

    public void BackButton()
    {
        save.SaveGame();
        PlayerPrefs.SetInt("SavedScene",SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync("Menu");
        
    }
}
