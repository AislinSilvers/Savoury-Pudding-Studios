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
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
            transform.forward = move;

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
    }
//sliding 
 void OnTriggerEnter(Collider other)
{
    //Debug.Log("hit");
     if(other.gameObject.tag == "Slide")
     {

            Debug.Log("slide");
            playerSpeed = 20f;
            isSprinting = true;

    }
}
void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Slide")
        {
            Debug.Log("stop");
            //to call the bool, need to name the struct! i think i figuered it out, very simple but got it i think
            //i figuered it out such a simple thing but it works!!!!!
            playerSpeed = 5.0f;
            isSprinting = false;
        }
    
        
    }
 
  
}