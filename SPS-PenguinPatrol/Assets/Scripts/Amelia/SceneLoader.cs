using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string loadScene = "Load";
   
    public string currentScene = "Antarctica";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            PlayerPrefs.SetString("LastScene", currentScene);
            SceneManager.LoadScene(loadScene);
        }
    }
}