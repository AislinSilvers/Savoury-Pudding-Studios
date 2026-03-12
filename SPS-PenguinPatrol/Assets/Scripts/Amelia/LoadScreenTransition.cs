using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTransition : MonoBehaviour
{
    public float waitTime = 10f;

    void Start()
    {
        Invoke("LoadNextScene", waitTime);
    }

    void LoadNextScene()
    {
        // load different scene depending on where we came from
        string lastScene = PlayerPrefs.GetString("LastScene");

        if (lastScene == "Antarctica")
        {
            SceneManager.LoadScene("Highlands");
        }
        else if (lastScene == "Highlands")
        {
            SceneManager.LoadScene("Caves");
        }
        else
        {
            // default fallback
            SceneManager.LoadScene("Highlands");
        }
    }
}