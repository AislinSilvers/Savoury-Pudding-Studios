using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerData : MonoBehaviour, IDataPersistence
{
    //these two are for saving the players position, for loading and saving the game, so whenever the player comes back they are in the same place.

    [Header("Debugging")]
    [SerializeField] public bool overrideSpawnPosition = false;
    [SerializeField] private Vector3 spawnOverridePosition;

    [Header("Set where the player starts")]
    public Vector3 startPosition;
    

    public void LoadData(GameData data)
    {
        if (overrideSpawnPosition)
        {
            this.transform.position = spawnOverridePosition;
            return;
        }
      
        else
        {
            this.transform.position = startPosition;
        }
        this.transform.position = data.playerPosition;
        
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
       
    }
}