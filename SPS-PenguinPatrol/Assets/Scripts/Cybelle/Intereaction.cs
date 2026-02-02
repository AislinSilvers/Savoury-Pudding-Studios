using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Intereaction : MonoBehaviour
{
    
    [SerializeField] GameObject objectToToggle;
    public GameObject buttonToggle;
    public InputActionReference press;


    
    private void OnTriggerEnter(Collider other)
    {
        

        Debug.Log("hit");
        if(other.gameObject.tag == "Player")
        {

            buttonToggle.SetActive(true);
            press.action.Enable();
            press.action.performed += context => objectToToggle.SetActive(!objectToToggle.activeSelf);
        

        }

    
    }


    void OnTriggerExit(Collider other)
    {
       buttonToggle.SetActive(false); 
       objectToToggle.SetActive(false);
       press.action.Disable();
       
      
    }
    

}
