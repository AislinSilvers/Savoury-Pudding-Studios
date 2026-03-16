using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//got from https://www.youtube.com/watch?v=W7UGintd7ek
//this is old code from prevouse game, deleted stuff not needed. rewated video to make sure it works as intended.

public class PlayerRespawn : MonoBehaviour,  IDataPersistence
{
    public Vector3 respawnPoint;
    public GameData data;
    public GameObject player;
    //public GameObject player;

    //public Spawnplayer playerPosData;

    public void Awake()
    {
       //transform.position = data.playerPosition;
       //playerPosData = FindObjectOfType<Spawnplayer>();
       //playerPosData.PlayerPosLoad();
       
    }

    public void RespawnNow()
    {
        //set player position, so that they reset.
        Debug.Log("respawn");
        player.transform.position = respawnPoint;
        
    }

     public void LoadData(GameData data)
    {
        //should load the player position
      transform.position = data.playerPosition;
       
    }

    public void SaveData(ref GameData data)
    {
        //saves the players position in the jason file, it does save i cna see it changing
        data.playerPosition = respawnPoint;
        
    }
    

   //ok so I have given up, sometiems the player location is saved mostof the time it doesnt so i am just letting the save for scene 
   //be the save for the virtical slice demo, if this was going to be a longer game I would find a way.
}