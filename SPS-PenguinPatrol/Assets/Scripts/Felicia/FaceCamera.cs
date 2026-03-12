using UnityEngine;
using UnityEngine.UI;

public class FaceCamera : MonoBehaviour
{
    /*
    //code from semester 2. it was used to make player's name always face the camera. in this project it makes npcInstance fly around tho
    [SerializeField] Transform npcInstance;
    Vector3 npcOffset = new Vector3(0, 1f, 0);
    void Start()
    {
        npcInstance.position = npcOffset;

    }
    private void LateUpdate()
    {
        npcInstance.LookAt(Camera.main.transform);
    }
    */

    [SerializeField] private Camera _mainCamera;

    private void LateUpdate()
    {
        Vector3 cameraPosition
            = _mainCamera.transform.position;
        cameraPosition.y
            = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, 180f, 0f);
    }


}
