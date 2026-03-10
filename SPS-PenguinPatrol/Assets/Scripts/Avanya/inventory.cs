using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField] GameObject accessory;
    bool accessoryOn;

    // void Start()
    // {
    //     if (accessory = null) 
    //     {
    //              accessory.SetActive (false);
    //          }
    // }

    public void toggleAccessory()
    {
        accessoryOn = !accessoryOn;
        Debug.Log(accessoryOn);


             if (accessoryOn == true)
        {
            accessory.SetActive(true);
        }
        else
        {
             accessory.SetActive(false);
        }

            }

            public void accessoryOff()
    {
        accessoryOn = false;
        accessory.SetActive(false);
    }
}
