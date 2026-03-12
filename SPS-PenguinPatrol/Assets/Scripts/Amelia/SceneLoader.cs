using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string loadScene = "Load";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // save which scene we are coming from so load screen knows where to go next
            PlayerPrefs.SetString("LastScene", "Highlands");
            SceneManager.LoadScene(loadScene);
        }
    }
}