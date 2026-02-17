using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //private PlayerRespawn playerRespawn;
    //public GameObject Triggered;
    //public GameObject SetState;
    //public GameObject Light;


    // Start is called before the first frame update
    void Start()
    {
        //playerRespawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //playerRespawn.respawnPoint = transform.position;
            //SetState.SetActive(false);
            //Triggered.SetActive(true);
            //Light.SetActive(true);
        }
    }
}


