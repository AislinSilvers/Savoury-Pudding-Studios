using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class rubbishCollection : MonoBehaviour
{
    //https://www.youtube.com/watch?v=6iSJ_jh6Rdo


    private int Currency = 0;

    [SerializeField] int price = 4;

    public TextMeshProUGUI currencyText;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "rubbish")
        {
            Currency++;
            currencyText.text = Currency.ToString();
            Destroy(other.gameObject);
        }
    }

    public void buyItem()
    {
        //nothing for now
    }
    
}
