using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField] GameObject accessory;
    bool accessoryOn = false;

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
}
