using UnityEngine;

public class moveToTarget : MonoBehaviour
{
       [SerializeField] Transform movementTarget;
        [SerializeField] Transform movingObject;
    public float speed; 
        public void MoveCrystals()
    {
        Debug.Log("this is working");
        movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, movementTarget.transform.position, speed);
    }


}
