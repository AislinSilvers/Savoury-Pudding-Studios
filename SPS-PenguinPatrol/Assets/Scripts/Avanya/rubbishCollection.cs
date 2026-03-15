using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class rubbishCollection : MonoBehaviour, IDataPersistence
{
    //https://www.youtube.com/watch?v=6iSJ_jh6Rdo
    [SerializeField] public int Currency = 0;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI hudCurrencyText;
    public GameObject hat1Button;
    public GameObject hat2Button;
    public GameObject hat3Button;
    public bool hat1Bought;
    public bool hat2Bought;
    public bool hat3Bought;

    void Start()
    {
        Currency = 0;
        UpdateCurrencyText();
    }

    public void UpdateCurrencyText()
    {
        if (currencyText) currencyText.text = Currency.ToString();
        if (hudCurrencyText) hudCurrencyText.text = Currency.ToString();
    }

    // adds 1 to the litter counter on collision with an object tagged as "rubbish"
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "rubbish")
        {
            Currency++;
            UpdateCurrencyText();
            Destroy(other.gameObject);
        }
    }

    public void BuyItem1()
    {
        hat1Bought = true;
        UpdateCurrencyText();
    }

    public void BuyItem2()
    {
        hat2Bought = true;
        UpdateCurrencyText();
    }

    public void BuyItem3()
    {
        hat3Bought = true;
        UpdateCurrencyText();
    }

    //buy item - this much currency
    //cybelle added save data info
    public void LoadData(GameData data)
    {
        hat1Bought = data.hatOne;
        hat2Bought = data.hatTwo;
        hat3Bought = data.hatThree;
    }

    public void SaveData(ref GameData data)
    {
        data.hatOne = hat1Bought;
        data.hatTwo = hat2Bought;
        data.hatThree = hat3Bought;
    }
}