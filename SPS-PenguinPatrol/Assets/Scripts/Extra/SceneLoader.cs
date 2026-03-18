using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string loadScene = "Load";
    public string currentScene = "Antarctica";
    public bool isFinalScene = false;
    public GameObject endGamePanel;

    void Start()
    {
        // portal hidden until baby penguin found
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isFinalScene)
            {
                // show end game panel instead of loading next scene
                if (endGamePanel) endGamePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                DataPersistenceManager.instance.SaveGame();
                PlayerPrefs.SetString("LastScene", currentScene);
                SceneManager.LoadScene(loadScene);
            }
        }
    }

    public void ActivatePortal()
    {
        gameObject.SetActive(true);
    }
}