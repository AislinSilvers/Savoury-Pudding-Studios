using UnityEngine;
using UnityEngine.Events;

public class musicTiles : MonoBehaviour
{
    [SerializeField] Transform musicParticles;
    public int musicNumber = 1;
    public UnityEvent tileHit;

    [Header("Sound")]
    public AudioClip tileSound;
    public AudioSource audioSource;
    public bool canTrigger;

    void Start()
    {
        canTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && (canTrigger = true))
        {
            if (audioSource && tileSound)
                audioSource.PlayOneShot(tileSound);
            canTrigger = false;

            tileHit.Invoke();
            Instantiate(musicParticles, transform.position, Quaternion.identity);

            Debug.Log(canTrigger);
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