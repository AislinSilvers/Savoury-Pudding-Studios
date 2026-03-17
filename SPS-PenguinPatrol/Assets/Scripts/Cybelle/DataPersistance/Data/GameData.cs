using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//all the save and load aka data managment from the youtuber Shaped by Rain Studios, and these videos https://www.youtube.com/watch?v=aUi9aijvpgs
//https://www.youtube.com/watch?v=ijVA5Z-Mbh8


//will update here as needed other data scripts also use this information, however to keep thing clear and clean will only have videos here for these, if add more save and load 
//featuers will add them on relatice scripts, will need to make a read me ot note will all the video together or an excel sheet. 


//the second video about the between scenes destorys the old game, if we want players to be able to go back to old scenes that cannot be used so i am adding a potiontal way
//to do saving/loading without destorying the scene https://www.youtube.com/watch?v=JFP-cCFID7o need to go over it in depth. 


//After talking with the team we decided the save between scens that destorys old scenes would be fine. since its a puzzle game.
[System.Serializable]
public class GameData
{
    //used data veriables
    //public Vector3 playerPosition;
    public bool hatOne;
    public bool hatTwo;
    public bool hatThree;
    public int currency;
    public long lastUpdated;

    //this isnt used anymore but like keep it in to show attempts at location fix
    public bool firstLoadArtic;
    public bool firstLoadHigh;
    public bool firstLoadCave;
    //public bool overRide;

    //saved scenes
    //public string currentScene;

    

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        //addes a value for saving the player posisiton
        //changed from Vector3.zero (0,0,0) to Y 3 so the player spawns above ground
        //if player still spawns underground, increase the Y value slightly
        //playerPosition = new Vector3(0, 3, 0);
        //this is probally the better way to do thing like more secuer and all that but its not working so i am mkaing a new code
        //with player prefabs, link to video helping me with that in its file.

        //adding hat bools to save? hopefully
        hatOne = false;
        hatTwo = false;
        hatThree = false;

        currency = 0;
        // position loading being a pain gonna have like a checkpoint based
        //why does it hate to save my location in scenes, i am gonna try to write in scens to save UGHHHHHHHHHH
        firstLoadArtic = true;
        firstLoadHigh = true;
        firstLoadCave = true;

        //overRide = true;



        //scenes
        
    }
}
