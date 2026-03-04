using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [SerializeField] private string currentScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        InitialState();
    }

    private void InitialState()
    {
        if (SceneManager.sceneCount == 1)
        {
            SetSceneName("Load");
        }
    }

    public void SetSceneName(string name)
    {
        if (SceneManager.sceneCount > 1 && !string.IsNullOrEmpty(currentScene))
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        currentScene = name;
    }

}
