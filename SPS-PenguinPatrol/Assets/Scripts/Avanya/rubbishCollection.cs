using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class rubbishCollection : MonoBehaviour
{
    //https://www.youtube.com/watch?v=6iSJ_jh6Rdo


    [SerializeField] public int Currency = 0;

    [SerializeField] int price = 15;

    public GameObject hat1Button;
    public GameObject hat2Button;
    public GameObject hat3Button;

    public bool hat1Bought;
    public bool hat2Bought;
    public bool hat3Bought;
    

    public TextMeshProUGUI currencyText;

    void Start()
    {
        Currency = 20;
        
            currencyText.text = Currency.ToString();
            
        
    }

// adds 1 to the litter counter on collision with an object tagged as "rubbish"
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "rubbish")
        {
            Currency++;
            currencyText.text = Currency.ToString();
            Destroy(other.gameObject);
        }
    }

    public void BuyItem1()
    {
        Debug.Log("hat2");

        if (Currency >= price)
        {
            Currency -= price;
            hat1Button.SetActive(true);
            hat1Bought = true;
        }
        else
        {
            return;
        }

        currencyText.text = Currency.ToString();

           Debug.Log(Currency);
    }


       public void BuyItem2()
    {
        Debug.Log("hat2");

        if (Currency >= price)
        {
            Currency -= price;
            hat2Button.SetActive(true);
            hat2Bought = true;
        }
        else
        {
            return;
        }

        currencyText.text = Currency.ToString();

           Debug.Log(Currency);
    }

       public void BuyItem3()
    {
        Debug.Log("hat3");

        if (Currency >= price)
        {
            Currency -= price;
            hat3Button.SetActive(true);
            hat3Bought = true;
        }
        else
        {
            return;
        }

        currencyText.text = Currency.ToString();

           Debug.Log(Currency);
    }


    //buy item - this much currency 
    
}
