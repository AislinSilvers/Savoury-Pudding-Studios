using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slide : MonoBehaviour
{


    public PlayerController otherScript;

    void Start()
    {

        GameObject g = GameObject.FindGameObjectWithTag ("Player");
        otherScript = g.GetComponent<PlayerController> ();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject.tag == "Player")
        {

            Debug.Log("slide");
            //otherScript.isSprinting = true;

        }

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("stop");
        //otherScript.isSprinting = false;
        
    }
}
