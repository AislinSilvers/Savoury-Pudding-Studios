using UnityEngine;
public class FollowPlayer : MonoBehaviour
{
    public GameObject chickObject;
    public GameObject playerObject;
    public float speed = 5f;
    public bool follow;

    
    public Vector3 followOffset = new Vector3(1f, 0f, 0f);

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
        if (!follow) return;

       
        Vector3 targetPosition = playerObject.transform.position +
                                 playerObject.transform.TransformDirection(followOffset);
        targetPosition.y = chickObject.transform.position.y; 
        float dist = Vector3.Distance(chickObject.transform.position, targetPosition);

        
        if (dist > 1f)
        {
            chickObject.transform.position = Vector3.MoveTowards(
                chickObject.transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

           
            chickObject.transform.LookAt(targetPosition);
        }
    }
}