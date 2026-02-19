using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    //[SerializeField] List<GameObject> puzzleStones = new List<GameObject>();
  public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");

        if (other.gameObject.tag == "puzzleStep1")
        {
            Debug.Log("correct!");
            GameObject.Find("Step1").GetComponent<Renderer>().material.color = Color.yellow;
        }

    }
}
