using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.UI;

//reference: unity discussions https://discussions.unity.com/t/ui-button-triggering-a-change-of-scene-after-an-animation-has-finished-im-new-please-help/786270/2
//&& https://discussions.unity.com/t/how-to-play-animation-of-a-button-first-then-only-proceeding-to-the-next-scene/241270/4

public class VideoStartDelay : MonoBehaviour
{
    public VideoPlayer cutscene;    //video itself , its in videoplayer 
    public RawImage videoDisplay; //assign VideoRenderTexture raw image 
    public RenderTexture renderTexture; //assign CutsceneRenderTexture, place where video shows up

    public string nextSceneName = "Antarctica";
    public float videoDuration = 10f;   //delay before scene loads

    [SerializeField] public GameObject menuPanel;   //assign MainMenuCanvas (to hide)
    [SerializeField] public GameObject cutscenePanel;

    void Start()
    {
        if (cutscene != null)
        {
            cutscenePanel.SetActive(false);

            cutscene.playOnAwake = false;   //not playing video in background

            cutscene.targetTexture = renderTexture; 

            if (videoDisplay != null)
                videoDisplay.texture = renderTexture;
        }
    }

    public void OnNewGame()
    {
        StartCoroutine(PlayVideo());    //starting video

        Invoke("LoadNext", videoDuration);  //regardless of outcome, force LoadNext to load next scene after delay, even if video doesnt play for some reason
    }

    IEnumerator PlayVideo()
    {
        menuPanel.SetActive(false); //hide MainMenuCanvas
        cutscenePanel.SetActive(true);

        if (cutscene != null)
        {
            cutscene.Play();    
        }

        yield return new WaitForSecondsRealtime(10f);   //delay
    }

    public void LoadNext()
    {
        //adding Cybelle's code from MainMenu cs
        
        Debug.Log("New Game Clicked");
        //creates a new game, which initializes our game data
        DataPersistenceManager.instance.NewGame();

        //end of Cybelle's code


        SceneManager.LoadSceneAsync("Antarctica");   //load first/next scene
    }
}
