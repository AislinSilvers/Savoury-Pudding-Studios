using UnityEngine;
using UnityEngine.Events;

public class musicTiles : MonoBehaviour
{
    [SerializeField] Transform musicParticles;
    public int musicNumber = 1;
    public UnityEvent tileHit;

    [Header("Sound")]
    public AudioClip tileSound;
    // public AudioSource audioSource;
    public bool canTrigger;

    void Start()
    {
        canTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && (canTrigger = true))
        {
            // if (audioSource && tileSound)
            //     audioSource.PlayOneShot(tileSound);
            soundFXManager.instance.playSoundFXClip(tileSound, transform, 1.7f);
            canTrigger = false;

            tileHit.Invoke();
            Instantiate(musicParticles, transform.position, Quaternion.identity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            canTrigger = true;

        }
    }
}