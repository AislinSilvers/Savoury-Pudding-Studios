using UnityEngine;
public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    public float distance = 6f;
    public float height = 2f;
    public float mouseSensitivity = 3f;
    public float verticalMinAngle = -20f;
    public float verticalMaxAngle = 60f;

    [Header("Collision")]
    public float minDistance = 1f; 
    public LayerMask collisionLayers; 

    private float yaw = 0f;
    private float pitch = 20f;

    void Start()
    {
        transform.SetParent(null);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LateUpdate()
    {
        if (target == null) return;

        
        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, verticalMinAngle, verticalMaxAngle);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredOffset = rotation * new Vector3(0, 0, -distance);
        Vector3 desiredPosition = target.position + Vector3.up * height + desiredOffset;

      
        RaycastHit hit;
        Vector3 direction = desiredPosition - (target.position + Vector3.up * height);
        float desiredDistance = direction.magnitude;

        if (Physics.Raycast(target.position + Vector3.up * height, direction.normalized, out hit, desiredDistance, collisionLayers))
        {
            
            float adjustedDistance = Mathf.Clamp(hit.distance - 0.2f, minDistance, distance);
            transform.position = target.position + Vector3.up * height + direction.normalized * adjustedDistance;
        }
        else
        {
            transform.position = desiredPosition;
        }

        transform.LookAt(target.position + Vector3.up * height);
    }
}