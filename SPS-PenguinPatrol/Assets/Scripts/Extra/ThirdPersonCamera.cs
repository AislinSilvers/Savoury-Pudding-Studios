using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    public float distance = 6f;
    public float height = 2f;
    public float verticalMinAngle = -20f;
    public float verticalMaxAngle = 60f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 3f;

    [Header("Controller Settings")]
    public float controllerSensitivityX = 3f;
    public float controllerSensitivityY = 2f;
    public bool invertControllerY = false;

    [Header("Scroll Zoom")]
    public float minZoom = 2f;
    public float maxZoom = 12f;
    public float scrollSpeed = 2f;
    public float zoomSmoothSpeed = 8f;

    [Header("Tunnel Settings")]
    public float tunnelZoom = 3f;
    public float tunnelHeight = 1f;
    public float tunnelTransitionSpeed = 3f;

    [Header("Collision")]
    public float minDistance = 1.5f;
    public float collisionRadius = 0.5f;
    public float collisionBuffer = 0.4f;
    public float smoothSpeedIn = 15f;
    public float smoothSpeedOut = 4f;
    public LayerMask collisionLayers;

    private float yaw = 0f;
    private float pitch = 20f;
    private float currentDistance;
    private bool inTunnel = false;
    private float normalHeight;

    // Separate saved zoom from active target zoom
    private float savedZoom;      // what zoom was before entering tunnel
    private float targetZoom;     // what zoom is moving toward right now

    void Start()
    {
        transform.SetParent(null);
        currentDistance = distance;
        targetZoom = distance;
        savedZoom = distance;
        normalHeight = height;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EnterTunnel()
    {
        inTunnel = true;
        normalHeight = height;
        savedZoom = targetZoom;   // save zoom BEFORE tunnel overrides it
    }

    public void ExitTunnel()
    {
        inTunnel = false;
        targetZoom = savedZoom;   // restore saved zoom from before tunnel
    }

    void LateUpdate()
    {
        if (target == null) return;

        HandleRotation();

        if (inTunnel)
        {
            // Force zoom in, no player control
            targetZoom = Mathf.Lerp(targetZoom, tunnelZoom, tunnelTransitionSpeed * Time.deltaTime);
            height = Mathf.Lerp(height, tunnelHeight, tunnelTransitionSpeed * Time.deltaTime);
        }
        else
        {
            // Restore height and allow zoom control
            height = Mathf.Lerp(height, normalHeight, tunnelTransitionSpeed * Time.deltaTime);
            HandleZoom();
        }

        distance = Mathf.Lerp(distance, targetZoom, zoomSmoothSpeed * Time.deltaTime);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 pivotPoint = target.position + Vector3.up * height;
        Vector3 direction = rotation * Vector3.back;

        float targetDistance = CheckCollision(pivotPoint, direction);
        float smoothSpeed = targetDistance < currentDistance ? smoothSpeedIn : smoothSpeedOut;
        currentDistance = Mathf.Lerp(currentDistance, targetDistance, smoothSpeed * Time.deltaTime);

        transform.position = pivotPoint + direction * currentDistance;
        transform.LookAt(pivotPoint);
    }

    void HandleRotation()
    {
        float inputX = 0f;
        float inputY = 0f;

        if (Input.GetMouseButton(1))
        {
            inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        }

        float stickX = GetAxisSafe("RightStickX");
        float stickY = GetAxisSafe("RightStickY");

        if (Mathf.Abs(stickX) > 0.1f)
            inputX += stickX * controllerSensitivityX;

        if (Mathf.Abs(stickY) > 0.1f)
            inputY += stickY * controllerSensitivityY * (invertControllerY ? -1f : 1f);

        yaw += inputX;
        pitch -= inputY;
        pitch = Mathf.Clamp(pitch, verticalMinAngle, verticalMaxAngle);
    }

    void HandleZoom()
    {
        // Mouse scroll
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0f)
        {
            targetZoom -= scroll * scrollSpeed * 10f;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }

        // Controller bumpers
        if (GetButtonSafe("ZoomIn"))
        {
            targetZoom -= scrollSpeed * Time.deltaTime * 10f;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }
        if (GetButtonSafe("ZoomOut"))
        {
            targetZoom += scrollSpeed * Time.deltaTime * 10f;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }

        savedZoom = targetZoom;   // keep savedZoom in sync while outside tunnel
    }

    float GetAxisSafe(string axisName)
    {
        try { return Input.GetAxis(axisName); }
        catch { return 0f; }
    }

    bool GetButtonSafe(string buttonName)
    {
        try { return Input.GetButton(buttonName); }
        catch { return false; }
    }

    float CheckCollision(Vector3 pivot, Vector3 direction)
    {
        float targetDistance = distance;

        RaycastHit hit;
        if (Physics.SphereCast(pivot, collisionRadius, direction, out hit, distance, collisionLayers))
        {
            targetDistance = Mathf.Min(targetDistance, hit.distance - collisionBuffer);
        }

        Vector3[] offsets = {
            rotation_Up(direction) * collisionRadius,
            rotation_Up(direction) * -collisionRadius,
            rotation_Right(direction) * collisionRadius,
            rotation_Right(direction) * -collisionRadius,
        };

        foreach (Vector3 offset in offsets)
        {
            Vector3 rayStart = pivot + offset;
            if (Physics.Raycast(rayStart, direction, out hit, distance, collisionLayers))
            {
                targetDistance = Mathf.Min(targetDistance, hit.distance - collisionBuffer);
            }
        }

        return Mathf.Clamp(targetDistance, minDistance, distance);
    }

    Vector3 rotation_Right(Vector3 dir) => Vector3.Cross(dir, Vector3.up).normalized;
    Vector3 rotation_Up(Vector3 dir) => Vector3.Cross(rotation_Right(dir), dir).normalized;
}