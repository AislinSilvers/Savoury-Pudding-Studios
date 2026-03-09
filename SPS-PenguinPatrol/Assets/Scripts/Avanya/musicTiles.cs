using UnityEngine;
using UnityEngine.Events;

public class musicTiles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform musicParticles;

    public int musicNumber = 1;

    public UnityEvent tileHit;

    private void OnTriggerEnter(Collider other)
    {
       if(other.transform.tag == "Player")
        {
            tileHit.Invoke();

            Instantiate(musicParticles, transform.position, Quaternion.identity);
        }


        


    }
}
