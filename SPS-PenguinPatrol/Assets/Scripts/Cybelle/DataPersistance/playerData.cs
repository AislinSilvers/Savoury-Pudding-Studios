using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerData : MonoBehaviour, IDataPersistence
{
    //these two are for saving the players position, for loading and saving the game, so whenever the player comes back they are in the same place.

    
    [Header("Debugging")]
    [SerializeField] private bool overrideSpawnPosition = false;
    [SerializeField] private Vector3 spawnOverridePosition = new Vector3(0, 3, 0);

    public void LoadData(GameData data)
    {
        
        if (overrideSpawnPosition)
        {
            this.transform.position = spawnOverridePosition;
            return;
        }
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
}