using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject chickObject;
    public GameObject playerObject;

    public float speed = 1f;
    
    


     void Start()
    {
       
    }

    void FixedUpdate()
    { 
       float dist = Vector3.Distance(chickObject.transform.position, playerObject.transform.position);
       if(dist > 2)
        {
            chickObject.transform.position = Vector3.MoveTowards(chickObject.transform.position, playerObject.transform.position, speed*Time.deltaTime);
        }

    }

    
}
