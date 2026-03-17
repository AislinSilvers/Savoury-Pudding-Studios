using System;
using UnityEngine;
using UnityEngine.InputSystem;

//used the playlist by chonk on youtube https://www.youtube.com/playlist, for movement, jump, and camera 
//old code and struggles is on the PlayerController script, with edits by others (I dont know who)

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerPlayer : MonoBehaviour
{
    [Header("Movement")]
    private Vector2 _input; 
    private CharacterController _characterController;
    private Vector3 _direction; 
    [SerializeField] private float speed;
    public bool isSprinting;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 500f;
    private Camera _mainCamera;
     

    [Header("Gravity")]
    private float _gravity = -9.81f; //-9.81 default gravity of earth 
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    [Header("Jump")]
    [SerializeField] private float jumpPower;
    //Amelias animation added
    [Header("Animation")]
    public Animator animator;

    [Header("Audio")]
    public AudioSource audioSource;
    private FootSteps footSteps;

   
   private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;

    }

     void Start()
    {
        footSteps = GameObject.Find("Player").GetComponent<FootSteps>();
    }

    private void Update()
    {
        ApplyRotation();
        ApplyGravity();
        ApplyMovement();

    }


    private void ApplyGravity()
    {
        if(IsGrounded() && _velocity < 0.0f)
        {
           _velocity = -1.0f; 
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        _direction.y = _velocity;

    }
    
    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;
        
        _direction = Quaternion.Euler(0.0f, _mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);

        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }

    private void ApplyMovement()
    {

        _characterController.Move(_direction * speed * Time.deltaTime);

    }

    public void Move(InputAction.CallbackContext context)
    {
        
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
        //animation
        animator.SetBool("isMoving", true);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        if(!IsGrounded()) return;
       
        _velocity += jumpPower;
        //animation
        animator.SetBool("isJumping", !IsGrounded());
    }

    private bool IsGrounded() => _characterController.isGrounded; 
    //codied from PlayerController script, bits of mine and Amelias code
      //sliding 
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit");
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("slide");
            footSteps.isWalking = false;
            speed = 20f;
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
            jumpPower = 5f;
            footSteps.isWalking = false;
        }

//        if (other.gameObject.tag == "Tunnel")
//        {
//            ThirdPersonCamera cam = Camera.main.GetComponent<ThirdPersonCamera>();
//            footSteps.isWalking = false;
//            if (cam != null) cam.EnterTunnel();
//        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("stop");
            footSteps.isWalking = false;
            //to call the bool, need to name the struct! i think i figuered it out, very simple but got it i think
            //i figuered it out such a simple thing but it works!!!!!
            speed = 5.0f;
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
            jumpPower = 1.5f;
            footSteps.isWalking = false;
        }

//        if (other.gameObject.tag == "Tunnel")
//        {
//            ThirdPersonCamera cam = Camera.main.GetComponent<ThirdPersonCamera>();
//            footSteps.isWalking = false;
//            if (cam != null) cam.ExitTunnel();
//        }
    }
}
