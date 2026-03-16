using UnityEngine;

public class FirstLoad : MonoBehaviour, IDataPersistence
{
    //fixed a like postition start code with code no longer used.
    public playerData playerScript;
    public bool articLoad;
    public bool highLoad;
    public bool caveLoad;


    public string currentScene = "Antarctica";
    
    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<playerData>();

        if (currentScene == "Caves" && caveLoad)
        {
           playerScript.overrideSpawnPosition = true;
        }
        else if (currentScene == "Highlands" && highLoad)
        {
            playerScript.overrideSpawnPosition = true;
        }
        else  if (currentScene == "Antarctica" && articLoad)
        {
             playerScript.overrideSpawnPosition = true;
        }
        
    }

   private void OnTriggerEnter(Collider other)
   {
       
          if (other.transform.tag == "Player" && currentScene == "Caves")
        {
            caveLoad = false;
            playerScript.overrideSpawnPosition = false;
        }
        else if (other.transform.tag == "Player" && currentScene == "Highlands")
        {
            highLoad = false;
            playerScript.overrideSpawnPosition = false;
        }
        else
        {
           articLoad = false;
           playerScript.overrideSpawnPosition = false;
        }
   }
     public void LoadData(GameData data)
    {
        
        articLoad = data.firstLoadArtic;
        highLoad = data.firstLoadHigh;
        caveLoad = data.firstLoadCave;
        
       
    }

    public void SaveData(ref GameData data)
    {
       
        data.firstLoadArtic = articLoad;
        data.firstLoadHigh = highLoad;
        data.firstLoadCave = caveLoad;
        
    }
}
