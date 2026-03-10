using UnityEngine;

//this code is from Multiplayer Game project Y3 Semester 1




//a smooth camera that follows a target player
public class ChaseCamera : MonoBehaviour
{
    //player transform the camera will follow.
    public static Transform player;

    [Header("Follow Settings")]
    [SerializeField] private float distance = 1f;       // distance behind the player
    [SerializeField] private float height = 1f;         // height above the player
    [SerializeField] private Vector3 offset = new Vector3(0, 1, 0);     // aim at the player

    [Header("Smoothing Settings")]
    [SerializeField] private float moveSpeed = 10f;     // camera speed
    [SerializeField] private float rotSpeed = 5f;      // camera rotation

    private void FixedUpdate()
    {
        if (player == null) return;

        //position to look at
        Vector3 lookPos = player.position + offset;

        //smooth rotation of camera to face player
        Quaternion targetRot = Quaternion.LookRotation(lookPos - transform.position);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRot,
            rotSpeed * Time.fixedDeltaTime
        );

        //calculate follow position
        Vector3 targetPos = player.position
                            + player.up * height
                            - player.forward * distance;

        //move camera toward the follow position
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            moveSpeed * Time.fixedDeltaTime
        );
    }
}