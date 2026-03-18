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
    public float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    public bool isSprinting;

    public AudioSource audioSource;

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

    private FootSteps footSteps;
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

    void Start()
    {
        footSteps = GameObject.Find("Player").GetComponent<FootSteps>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = camForward * input.y + camRight * input.x;
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15f * Time.deltaTime);
            animator.SetBool("isMoving", true);
            footSteps.isWalking = true;
        }
        else
        {
            animator.SetBool("isMoving", false);
            footSteps.isWalking = false;
        }

        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;


        Physics.SyncTransforms();
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);

        animator.SetBool("isJumping", !groundedPlayer);
    }

    //sliding 
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("slide");
            footSteps.isWalking = false;
            playerSpeed = 20f;
            isSprinting = true;
            animator.SetBool("isSliding", true);
            audioSource.Play();
            
        }

        if (other.gameObject.tag == "Water")
        {
            animator.SetBool("isSwimming", true);
            footSteps.isWalking = false;
        }

        if (other.gameObject.tag == "Mushroom")
        {
            jumpHeight = 5f;
            footSteps.isWalking = false;
        }

        if (other.gameObject.tag == "Tunnel")
        {
            ThirdPersonCamera cam = Camera.main.GetComponent<ThirdPersonCamera>();
            footSteps.isWalking = false;
            if (cam != null) cam.EnterTunnel();
        }

        if (other.gameObject.tag == "WalkFaster")
        {
    
            playerSpeed = 10f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("stop");
            footSteps.isWalking = false;
            //to call the bool, need to name the struct! i think i figuered it out, very simple but got it i think
            //i figuered it out such a simple thing but it works!!!!!
            playerSpeed = 5.0f;
            isSprinting = false;
            animator.SetBool("isSliding", false);
            audioSource.Stop();
        }

        if (other.gameObject.tag == "Water")
        {
            animator.SetBool("isSwimming", false);
            footSteps.isWalking = false;
        }

        if (other.gameObject.tag == "Mushroom")
        {
            jumpHeight = 1.5f;
            footSteps.isWalking = false;
        }

        if (other.gameObject.tag == "Tunnel")
        {
            ThirdPersonCamera cam = Camera.main.GetComponent<ThirdPersonCamera>();
            footSteps.isWalking = false;
            if (cam != null) cam.ExitTunnel();
        }
    }
}
