using UnityEngine;
using UnityEngine.UI;

public class FaceCamera : MonoBehaviour
{
    //nice tutorial https://youtu.be/rOVLui_twYI?si=zg1g479NxtJ7AizP
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform); //whatever this code is linked to (any NPC) will always face camera
    }


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


    /*
     //another code but for 'player' to alwya face camera, prob not for npcs https://youtube.com/shorts/KGG2V4ZkXTg?si=ITPHerr4NF8K5YuW 
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
    */


}
