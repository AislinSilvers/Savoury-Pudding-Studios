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



    public void RespawnNow()
    {
        transform.position = respawnPoint;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            RespawnNow();
        }
    }

     public void LoadData(GameData data)
    {
      transform.position = data.playerPosition;
       
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = respawnPoint;
        
    }
    

   
}