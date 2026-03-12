using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string loadScene = "Load";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("LastScene", "Antarctica");
            SceneManager.LoadScene(loadScene);
        }
    }
}