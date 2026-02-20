using System;
using UnityEngine;
using UnityEngine.InputSystem;


//used the playlist by chonk on youtube https://www.youtube.com/playlist?list=PLBcfp6HMOJwzDcdCzoAx3jJKm7sIcBXJZ to learn the input system and be able to make the player move
//this code was writen while watching the video aka its code in the video but i made sure to watch and listen to the exsplantions so that i Understadn what is happening. 
//ended up changing the movemnt code from character controller to ridgid body, deleted the old code to keep the code clean
//hoping to use the ray cast from the https://www.youtube.com/watch?v=qdskE8PJy6Q in the updated code
//ended up scraping the old code completly and am using new code with ridgid body and input system.https://www.youtube.com/watch?v=1LtePgzeqjQ



[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{

     public Rigidbody rb;
     public float speed, sensitivity;
     private Vector2 move;

    // [Header("Movement")]
    
    
    
    // [Header("Rotation")]
    
    public void OnMove(InputAction.CallbackContext context)
    {
        

    }

    //private void ApplyRotation()
    //{
        //this is to fix the player returning to start position facing wise, aka make the frount face last looked dirrection
        //if (_input.sqrMagnitude == 0) return;

        //the angle math so that it can move more smoothly 
       // var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
       // var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        


    //}

    //private void ApplyMovement()
    //{

        //this is the sprinitng code, which i am just going to use as a sliding mechanic
        //var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;
		//movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.acceleration * Time.deltaTime);
        //this is the actualy movment code
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        

    //}

    //this is the move function and it links to the input system which is the context so that is knows what buttons and gamepad can be used
    //public void Move(InputAction.CallbackContext context)
    //{
        //_input = context.ReadValue<Vector2>();
        //_direction = new Vector3(_input.x, 0.0f, _input.y);


    //}

// [Serializable]
// public struct Movement
// {
// 	public float speed;
// 	public float multiplier;
// 	public float acceleration;

//     public bool isSprinting;
//     public float currentSpeed;
// }
//coding the slide code which is just the sprint code from the playlist, but instead of using the input system i am using triggers to active the bool 
//public void OnTriggerEnter(Collider other)
//{
   // Debug.Log("hit");
     //if(other.gameObject.tag == "Slide")
     //{

            //Debug.Log("slide");
            //movement.isSprinting = true;

    //}
//}
//void OnTriggerExit(Collider other)
    //{
        //if(other.gameObject.tag == "Slide")
        //{
            //Debug.Log("stop");
            //to call the bool, need to name the struct! i think i figuered it out, very simple but got it i think
            //i figuered it out such a simple thing but it works!!!!!
           // movement.isSprinting = false;
       // }
    
        
   // }


  
}
