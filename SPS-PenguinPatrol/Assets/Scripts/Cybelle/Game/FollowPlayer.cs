using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public float smoothSpeed = 8f;
    public float rotationSpeed = 5f;
    public bool follow = false;
    public Vector3 followOffset = new Vector3(2f, 0f, -1f);

    void Start()
    {
        follow = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            follow = true;
        }
    }

    void Update()
    {
        if (!follow) return;

        Vector3 targetPosition = playerObject.transform.position + playerObject.transform.TransformDirection(followOffset);
        targetPosition.y = transform.position.y;

        transform.position = Vector3.Lerp(transform.position,targetPosition,smoothSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.Euler(0,playerObject.transform.eulerAngles.y + 180f,0);

        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, rotationSpeed * Time.deltaTime);
    }
}
//cybelle here i see all my code besides the very top was changed and i was never told and my old code was deleted, very frustrating. 
//also I dont like how clsoe the baby gets to the player and my old code had a distance away to fix this. 
//so I am gonna change it.