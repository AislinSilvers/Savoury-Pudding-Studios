using System;
using UnityEngine;
using UnityEngine.InputSystem;
//(this is all old refs) used the playlist by chonk on youtube https://www.youtube.com/playlist?list=PLBcfp6HMOJwzDcdCzoAx3jJKm7sIcBXJZ to 
//learn the input system and be able to make the player move
//ended up changing the movemnt code from character controller to ridgid body
//will delete the old code to keep it clean, if need it its in the older github pushes
//hoping to use the ray cast from the https://www.youtube.com/watch?v=qdskE8PJy6Q in the updated code (not used as of yet)
//ended up scraping the old code completly and am using new code with ridgid body and input system.https://www.youtube.com/watch?v=1LtePgzeqjQ
//this is code from unity, has basic movemnt and jumping
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    public bool isSprinting;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    //this is what makes the imput system work
    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    // Camera reference so movement is relative to where the camera is looking
    // drag your Camera into this slot in the Inspector
    [Header("Camera")]
    public Transform cameraTransform;

    // Drag the penguin mesh child object into this slot in the Inspector
    [Header("Animation")]
    public Animator animator;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Get camera forward/right but flatten on Y so moving forward
        // doesnt send the player up or down based on camera tilt
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Move relative to camera direction instead of world direction
        Vector3 move = camForward * input.y + camRight * input.x;
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15f * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        // Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);

        // Drive animations
        animator.SetBool("isJumping", !groundedPlayer);
    }

    //sliding 
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("slide");
            playerSpeed = 20f;
            isSprinting = true;
            animator.SetBool("isSliding", true);
        }

        // When penguin enters water, trigger swim animation
        if (other.gameObject.tag == "Water")
        {
            animator.SetBool("isSwimming", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("stop");
            //to call the bool, need to name the struct! i think i figuered it out, very simple but got it i think
            //i figuered it out such a simple thing but it works!!!!!
            playerSpeed = 5.0f;
            isSprinting = false;
            animator.SetBool("isSliding", false);
        }

        // When penguin leaves water, stop swim animation
        if (other.gameObject.tag == "Water")
        {
            animator.SetBool("isSwimming", false);
        }
    }
}