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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (audioSource && tileSound)
                audioSource.PlayOneShot(tileSound);
            Debug.Log("banana");

            tileHit.Invoke();
            Instantiate(musicParticles, transform.position, Quaternion.identity);
        }
    }
}