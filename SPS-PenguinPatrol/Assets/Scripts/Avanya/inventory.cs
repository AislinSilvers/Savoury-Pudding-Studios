using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField] GameObject accessory;
        bool accessoryOn;

        //buying items variables
    public rubbishCollection litterScript;
    // public int money; 
    // int currency;

    void Start()
    {
        litterScript = GameObject.Find("Player").GetComponent<rubbishCollection>();
    }

    //toggling accessories on and off

    public void toggleAccessory()
    {
        accessoryOn = !accessoryOn;
        //Debug.Log(accessoryOn);
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

    

    //buying functions 

    public void buyItem1()
    {
       litterScript.BuyItem1();
    }

    public void buyItem2()
    {
       litterScript.BuyItem2();
    }

    public void buyItem3()
    {
       litterScript.BuyItem3();
    }
}
