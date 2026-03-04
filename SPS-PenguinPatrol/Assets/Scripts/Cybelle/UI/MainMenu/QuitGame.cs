using UnityEngine;

public class QuitGame : MonoBehaviour
{
//this is the quit game script i learned in first year, have been using it ever since
    public void QuitGameButton()
    {

        Application.Quit();
        
        Debug.Log("Application has quit");

    }
}
