using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;
    
    [SerializeField] private float speed;

    private void Awake()
    {
        //getting the character controller to be able to move the player
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //this is if the nothing is happening return aka do nothing
        if (_input.sqrMagnitude == 0) return;
        //the movement and angle math so that it can move more smoothly 
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        
        _characterController.Move(_direction * speed * Time.deltaTime);
    }
//this is the move function and it links to the input system which is the context so that is knows what buttons and gamepad can be used
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }
}
