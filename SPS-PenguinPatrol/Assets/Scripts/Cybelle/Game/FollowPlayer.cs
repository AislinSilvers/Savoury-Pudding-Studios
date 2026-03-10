using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject chickObject;
    public GameObject playerObject;

    public float speed = 1f;
    public bool follow;
    
    


     void Start()
    {
        follow = false;   
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("follow");
            follow = true;
        }


    }

    void FixedUpdate()
    { 
        
       float dist = Vector3.Distance(chickObject.transform.position, playerObject.transform.position);
       if(dist > 2 && follow)
        {
            chickObject.transform.position = Vector3.MoveTowards(chickObject.transform.position, playerObject.transform.position, speed*Time.deltaTime);
        }

    }



    
}
