//NONE OF THIS DAMN SHIT WORKS

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapStamps : MonoBehaviour
{
    [SerializeField] public GameObject stampAntarctica;
    [SerializeField] public GameObject stampHighlands;
    [SerializeField] public GameObject stampCave;
    
    [SerializeField] public string scene1 = "Antarctica";
    [SerializeField] public string scene2 = "Highlands";
    [SerializeField] public string scene3 = "Caves";


    /*
    private void Awake()
    {
        stampAntarctica.SetActive(false);
        stampHighlands.SetActive(false);
        stampCave.SetActive(false);
    }

    private void OnEnable()
    {
        UpdateStamps();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetString($"Visited_{scene.name}", "true");
        PlayerPrefs.Save();

        UpdateStamps();
    }

    private void UpdateStamps()
    {
        if (HasVisited(scene1) && stampAntarctica != null)
            stampAntarctica.SetActive(true);

        if (HasVisited(scene2) && stampHighlands != null)
            stampHighlands.SetActive(true);

        if (HasVisited(scene3) && stampCave != null)
            stampCave.SetActive(true);
    }

    private bool HasVisited(string sceneName)
    {
        return PlayerPrefs.GetString($"Visited_{sceneName}", "false") == "true";
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey($"Visited_{scene1}");
        PlayerPrefs.DeleteKey($"Visited_{scene2}");
        PlayerPrefs.DeleteKey($"Visited_{scene3}");
    }
    */



    /*
    private void OnTriggerEnter(Collider other)
    {
        string lastScene = PlayerPrefs.GetString("LastScene");

        if (lastScene == "Antarctica" && other.gameObject.tag == "Player")
        {
            stampAntarctica.SetActive(true);
        }
        else if (lastScene == "Highlands" && other.gameObject.tag == "Player")
        {
            stampHighlands.SetActive(true);
        }
        else if (lastScene == "Caves" && other.gameObject.tag == "Player")
        {
            stampHighlands.SetActive(true);
        }
    }
    */
}
