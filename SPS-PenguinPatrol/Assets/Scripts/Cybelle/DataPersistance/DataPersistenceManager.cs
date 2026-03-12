using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class DataPersistenceManager : MonoBehaviour
{
    //all this code was made form the same video as the GameData script, videos in that scripts notes
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;
    // tick this in the inspector to force reset the player spawn position back to default
    // tick it once, press play, it will save the correct position, then untick it again
    // this wont affect anyone elses save file, only yours locally
    [SerializeField] private bool resetPlayerPosition = false;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }
    private void Awake()
    {
        //makes sure there is only one of these scripts, so there is no conflicts
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded Called");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded Called");
        SaveGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        //load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();
        if (this.gameData == null && initializeDataIfNull)
        {
            //will need to toggle the bool on for testing save stuff in scenes if we dont want to go though the whole main menu
            NewGame();
        }
        //if no data can be loaded, initialize to a new game (according to video), basically load game dosent work unless there is loaded data, make new save if not data
        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded");
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        // if resetPlayerPosition is ticked in the inspector, override the loaded position
        // with the default spawn position and save it so it sticks
        // untick after pressing play once to stop it resetting every time
        if (resetPlayerPosition)
        {
            gameData.playerPosition = new Vector3(0, 3, 0);
            SaveGame();
            resetPlayerPosition = false;
        }
    }
    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No date was found. A New Game needs to be strted before data can be saved.");
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        // FindObjectsofType takes in an optional boolean to include inactive gameobjects
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    public bool HasGameData()
    {
        return gameData != null;
    }
}