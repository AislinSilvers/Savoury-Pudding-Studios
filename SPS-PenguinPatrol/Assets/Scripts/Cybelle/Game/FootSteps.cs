using UnityEngine;

public class FootSteps : MonoBehaviour
{

    public AudioSource audioSource;
    private Vector3 lastPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // Check if the player has moved since the last frame
        if (transform.position != lastPosition)
        {
            // If the player is moving and the sound is not already playing, play the sound
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // If the player is not moving, stop the sound
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // Update last position for the next frame
        lastPosition = transform.position; 
    }
}
