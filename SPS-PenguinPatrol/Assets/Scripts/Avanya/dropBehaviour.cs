using UnityEngine;

public class dropBehaviour : MonoBehaviour
{
    public Transform dropScatter;

    // Update is called once per frame
     void OnTriggerEnter(Collider other)
    {
             if (other.transform.tag == "crystal")
             {
                Instantiate(dropScatter, transform.position, Quaternion.identity);
            Destroy(gameObject);
            }
            
            if (other.transform.tag == "Player")
             {
                Instantiate(dropScatter, transform.position, Quaternion.identity);
            Destroy(gameObject);
            }

    }
}
