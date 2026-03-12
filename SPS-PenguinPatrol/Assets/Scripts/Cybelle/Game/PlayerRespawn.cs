using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//got from https://www.youtube.com/watch?v=W7UGintd7ek
//this is old code from prevouse game, deleted stuff not needed. rewated video to make sure it works as intended.
//updated to save last safe position so player respawns where they last were before hitting water
public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    private Vector3 lastSafePosition;

    void Start()
    {
        // set last safe position to starting position at the beginning
        lastSafePosition = transform.position;
    }

    void Update()
    {
        // keep saving position every frame as long as player is on safe ground
        // only updates when not in water
        if (!inWater)
        {
            lastSafePosition = transform.position;
        }
    }

    private bool inWater = false;

    public void RespawnNow()
    {
        transform.position = lastSafePosition;
        inWater = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            RespawnNow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = true;
            RespawnNow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = false;
        }
    }
}