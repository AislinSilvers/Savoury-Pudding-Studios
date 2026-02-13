using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //public Vector3 respawnPoint;

    //public void RespawnNow()
    //{
        //transform.position = respawnPoint;
    //}

    //private void OnCollisionEnter2D (Collision2D collision)
    //{
        //if(collision.gameObject.tag == "Death")
        //{
            //GameObject.Find("Player").GetComponent<Animator>().speed = 0; 
           // GameObject.Find("Main Camera").GetComponent<Animator>().Play("Shake");
            //GameObject.Find("Player").GetComponent<PlayerMovement2D>().moveSpeed = 0f;
            //GameObject.Find("Player").GetComponent<PlayerMovement2D>().maxJumps = 0;
           // StartCoroutine(DeathWait());
           // GameObject.Find("Player").GetComponent<PlayerMovement2D>().enabled = false;
            //GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            //RespawnNow();
            //GetComponent<AudioSource>().Play();
        //}
    //}
   //IEnumerator DeathWait()
   //{
    //yield return new WaitForSeconds(1);

    //RespawnNow();
    //GameObject.Find("Player").GetComponent<Animator>().speed = 1; 
    //GameObject.Find("Main Camera").GetComponent<Animator>().Play("New State");
    //GameObject.Find("Player").GetComponent<PlayerMovement2D>().moveSpeed = 20f;
    //GameObject.Find("Player").GetComponent<PlayerMovement2D>().maxJumps = 2;
    //GameObject.Find("Player").GetComponent<PlayerMovement2D>().enabled = true;
    //GameObject.Find("Player").GetComponent<Animator>().enabled = true;

   //}
}

//got from https://www.youtube.com/watch?v=W7UGintd7ek
//I was messing around with how to do a camera shake and also stop the movement, since time freeze made camera shake death 
//camera shake, the end with the best result was the enable-disable of companets although the othes kinda worked
//I am sure there is a way to add the freeze time with an exseption of camera shake and the wait compnete
//but i am not sure how to properly implument that
