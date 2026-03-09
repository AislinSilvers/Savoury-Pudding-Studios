using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour,IDataPersistence
{
 //these two are for saving the players position, for loading and saving the game, so whenever the player comes back they are in the same place.
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;

    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;

    }
}
