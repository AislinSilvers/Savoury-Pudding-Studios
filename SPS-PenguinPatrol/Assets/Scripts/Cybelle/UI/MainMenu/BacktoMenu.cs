using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BacktoMenu : MonoBehaviour
{
    public void BackButton()
    {
       
        SceneManager.LoadSceneAsync("Menu");
    }
}
