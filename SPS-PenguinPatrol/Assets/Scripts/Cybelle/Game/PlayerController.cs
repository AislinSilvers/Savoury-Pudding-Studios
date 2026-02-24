using System;
using UnityEngine;
using UnityEngine.InputSystem;


//(this is all old refs) used the playlist by chonk on youtube https://www.youtube.com/playlist?list=PLBcfp6HMOJwzDcdCzoAx3jJKm7sIcBXJZ to 
//learn the input system and be able to make the player move

//ended up changing the movemnt code from character controller to ridgid body
//will delete the old code to keep it clean, if need it its in the older github pushes

//hoping to use the ray cast from the https://www.youtube.com/watch?v=qdskE8PJy6Q in the updated code (not used as of yet)
//ended up scraping the old code completly and am using new code with ridgid body and input system.https://www.youtube.com/watch?v=1LtePgzeqjQ



[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour, IDataPersistence
{
    [Header("Movement")]
    public Rigidbody rb;
    public float speed, sensitivity, maxForce, rotSpeed;
    private Vector2 move,look;
    public Vector3 startPos = Vector3.zero;
    public Vector3 startRot = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.localEulerAngles;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();

    }
//these two are for saving the players position, for loading and saving the game, so whenever the player comes back they are in the same place.
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;

    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;

    }

    
//this is the cleaner way to orgnize code, making a seprate method and calling it on fixed update. 
    private void FixedUpdate()
    {
        Move();
    }

   
//this has all the move code in it 
    void Move()
    {

        float translation, rotation;

        translation = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        rotation = Input.GetAxis("Horizontal") * rotSpeed * Time.fixedDeltaTime;

        //Find target velocity (according to the video)
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 targetVelocity = new Vector3(move.x,0,move.y);
        targetVelocity *= speed;

        //Allign direction (according to video)
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces (according to video)
        Vector3 velocityChange = (targetVelocity - currentVelocity);

        //Limit force (according to video)
        Vector3.ClampMagnitude(velocityChange, maxForce);

        //this actually moves the player
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        //the turn code, for turning the player as they move, need to add in space self somehow and get a better grip on how this properlly works
        //maybe need to freshin up on my maths 
        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turn);



        
    }


  
}
