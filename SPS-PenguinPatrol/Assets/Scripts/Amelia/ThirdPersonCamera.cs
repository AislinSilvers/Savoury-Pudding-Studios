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

    private float yaw = 0f;
    private float pitch = 20f;

    void Start()
    {
        // Detach from parent at runtime so player rotation doesn't affect us
        transform.SetParent(null);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, verticalMinAngle, verticalMaxAngle);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        transform.position = target.position + Vector3.up * height + offset;
        transform.LookAt(target.position + Vector3.up * height);
    }
}