using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//got from https://www.youtube.com/watch?v=W7UGintd7ek
//this is old code from prevouse game, deleted stuff not needed. rewated video to make sure it works as intended.

public class PlayerRespawn : MonoBehaviour,  IDataPersistence
{
    public Vector3 respawnPoint;
    public Vector3 startPoint;
    public GameData data;
    //public Transform spawn;

     //public string currentScene = "Antarctica";

    //public bool articLoad = true;
   // public bool highLoad = true;
   // public bool caveLoad = true;

    //public Spawnplayer playerPosData;

    //public void Awake()
   // {
        //transform.position = startPoint;
        
//
//        if (currentScene == "Caves" && caveLoad)
//        {
//            transform.position = startPoint;
//            //caveLoad = false;
//        }
//        else if (currentScene == "Highlands" && highLoad)
//        {
//             transform.position = startPoint;
//            //highLoad = false;
//        }
//        else  if (currentScene == "Antarctica" && articLoad)
//        {
//              transform.position = startPoint;
//            //articLoad = false;
//        }
//       
    //}

    public void Start()
    {
       transform.position = startPoint;
    }

    public void RespawnNow()
    {
        //set player position, so that they reset.
        transform.position = respawnPoint;
        
    }

     public void LoadData(GameData data)
    {
        //should load the player position
      //transform.position = data.playerPosition;
      //articLoad = data.firstLoadArtic;
      //highLoad = data.firstLoadHigh;
      //caveLoad = data.firstLoadCave;
       
    }

    public void SaveData(ref GameData data)
    {
        //saves the players position in the jason file, it does save i cna see it changing
        //data.playerPosition = respawnPoint;
        //data.firstLoadArtic = articLoad;
        //data.firstLoadHigh = highLoad;
        //data.firstLoadCave = caveLoad;
        
    }
    

   //ok so I have given up, sometiems the player location is saved mostof the time it doesnt so i am just letting the save for scene 
   //be the save for the virtical slice demo, if this was going to be a longer game I would find a way.
}
