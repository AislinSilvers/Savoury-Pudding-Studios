using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all the save and load aka data managment from the youtuber Shaped by Rain Studios, and these videos https://www.youtube.com/watch?v=aUi9aijvpgs
//https://www.youtube.com/watch?v=ijVA5Z-Mbh8
//will update here as needed other data scripts also use this information, however to keep thing clear and clean will only have videos here for these, if add more save and load 
//featuers will add them on relatice scripts, will need to make a read me ot note will all the video together or an excel sheet. 

[System.Serializable]
public class GameData 
{
  public Vector3 playerPosition;

 // the values defined in this constructor will be the default values
 // the game starts with when there's no data to load

  public GameData()
  {
    //addes a value for saving the player posisiton
    playerPosition = Vector3.zero;
  }
}
