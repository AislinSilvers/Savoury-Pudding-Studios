using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//got from https://www.youtube.com/watch?v=W7UGintd7ek
//this is old code from prevouse game, deleted stuff not needed. rewated video to make sure it works as intended.
public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;

    public void RespawnNow()
    {
        transform.position = respawnPoint;
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Death")
        {

            RespawnNow();
            
        }
    }

}
 


