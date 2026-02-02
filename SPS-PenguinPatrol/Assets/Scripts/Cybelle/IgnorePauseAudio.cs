using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IgnorePauseAudio : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.ignoreListenerPause = true;
    }

}
