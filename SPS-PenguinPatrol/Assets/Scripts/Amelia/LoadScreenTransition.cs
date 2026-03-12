using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTransition : MonoBehaviour
{
    public string sceneToLoad = "Highlands";
    public float waitTime = 10f;

    void Start()
    {
        Invoke("LoadNextScene", waitTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}