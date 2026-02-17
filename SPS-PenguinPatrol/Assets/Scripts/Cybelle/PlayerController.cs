using System;
using UnityEngine;
using UnityEngine.InputSystem;


//used the playlist by chonk on youtube https://www.youtube.com/playlist?list=PLBcfp6HMOJwzDcdCzoAx3jJKm7sIcBXJZ to learn the input system and be able to make the player move
//this code was writen while watching the video aka its code in the video but i made sure to watch and listen to the exsplantions so that i Understadn what is happening. 


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private Movement movement;
    
    [Header("Rotation")]
    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    [Header("Gravity")]
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _gravity = -9.81f;
    private float _velocity;

    [Header("Jump")]
    [SerializeField] private float jumpPower;

    private void Awake()
    {
        //getting the character controller to be able to move the player
        _characterController = GetComponent<CharacterController>();
    }


    private void FixedUpdate()
    {
        //getting the movement, rotations and gravity

        ApplyGravity();
        ApplyRotation();
        ApplyMovement();


        
    }

    private void ApplyGravity()
    {
        //so make the fall not be a snap, aka more smooth
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }

    //basic gravity code
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        
        _direction.y = _velocity;

    }

    private void ApplyRotation()
    {
        //this is to fix the player returning to start position facing wise, aka make the frount face last looked dirrection
        if (_input.sqrMagnitude == 0) return;

        //the angle math so that it can move more smoothly 
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

    }

    private void ApplyMovement()
    {

        //this is the sprinitng code, which i am just going to use as a sliding mechanic
        var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;
		movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);
        //this is the actualy movment code
         _characterController.Move(_direction * movement.currentSpeed  * Time.deltaTime);

    }

    //this is the move function and it links to the input system which is the context so that is knows what buttons and gamepad can be used
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);


        if(IsGrounded())
        {
           _direction.y =-4.5f;  
        }

    }

    //this is what makes jumping possible, using the input system.
    public void Jump(InputAction.CallbackContext context)
    {
    //this is making sure it is grounded and that the button is pressed, and only whne it is pressed ignoring the rest of the states of the button
        if (!context.started) return;
        if (!IsGrounded()) return;
    //actual jumping code
        _velocity += jumpPower;
    }
    //this code can be used as a button in input system, although i am going to try and call the sprnting on the area itself we shall see if it work
   
    //this is how it will check if it is grounded, just considedered a cleaner way to check and call this
    private bool IsGrounded() => _characterController.isGrounded;

[Serializable]
public struct Movement
{
	public float speed;
	public float multiplier;
	public float acceleration;

    public bool isSprinting;
    public float currentSpeed;
}
//coding the slide code which is just the sprint code from the playlist, but instead of using the input system i am using triggers to active the bool 
public void OnTriggerEnter(Collider other)
{
    Debug.Log("hit");
     if(other.gameObject.tag == "Slide")
     {

            Debug.Log("slide");
            movement.isSprinting = true;

    }
}
void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Slide")
        {
            Debug.Log("stop");
            //to call the bool, need to name the struct! i think i figuered it out, very simple but got it i think
            //i figuered it out such a simple thing but it works!!!!!
            movement.isSprinting = false;
        }
    
        
    }
  
}
