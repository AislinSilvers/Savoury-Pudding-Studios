using UnityEngine;

public class inventory : MonoBehaviour
{
    [Header("Panel")]
    public GameObject inventoryShopPanel;
    public GameObject inventoryButton;

    [Header("Accessories - on penguin sprite in shop UI")]
    public GameObject gogglesOnPenguin;
    public GameObject kiltOnPenguin;
    public GameObject hatOnPenguin;

    [Header("3D Models - on actual player in scene")]
    public GameObject goggles3DModel;
    public GameObject kilt3DModel;
    public GameObject hat3DModel;

    [Header("Buy Buttons - shown when enough trash")]
    public GameObject hat1BuyButton;
    public GameObject hat2BuyButton;
    public GameObject hat3BuyButton;

    [Header("Item Sprites - always visible but greyed until affordable")]
    public UnityEngine.UI.Image hat1Image;
    public UnityEngine.UI.Image hat2Image;
    public UnityEngine.UI.Image hat3Image;

    [Header("Costs")]
    public int hat1Cost = 25;
    public int hat2Cost = 30;
    public int hat3Cost = 35;

    private bool gogglesOn;
    private bool kiltOn;
    private bool hatOn;

    //buying items variables
    public rubbishCollection litterScript;

    void Start()
    {
        litterScript = GameObject.Find("Player").GetComponent<rubbishCollection>();

        if (inventoryShopPanel) inventoryShopPanel.SetActive(false);
        if (inventoryButton) inventoryButton.SetActive(true);

        if (gogglesOnPenguin) gogglesOnPenguin.SetActive(false);
        if (kiltOnPenguin) kiltOnPenguin.SetActive(false);
        if (hatOnPenguin) hatOnPenguin.SetActive(false);

        if (goggles3DModel) goggles3DModel.SetActive(false);
        if (kilt3DModel) kilt3DModel.SetActive(false);
        if (hat3DModel) hat3DModel.SetActive(false);

        if (hat1BuyButton) hat1BuyButton.SetActive(false);
        if (hat2BuyButton) hat2BuyButton.SetActive(false);
        if (hat3BuyButton) hat3BuyButton.SetActive(false);

        UpdateShop();
    }

    void Update()
    {
        UpdateShop();
    }

    //toggling inventory panel open and closed
    public void OpenInventory()
    {
        if (inventoryShopPanel) inventoryShopPanel.SetActive(true);
        if (inventoryButton) inventoryButton.SetActive(false);
    }

    public void CloseInventory()
    {
        if (inventoryShopPanel) inventoryShopPanel.SetActive(false);
        if (inventoryButton) inventoryButton.SetActive(true);
    }

    void UpdateShop()
    {
        if (litterScript == null) return;

        if (!litterScript.hat1Bought)
        {
            bool canAfford1 = litterScript.Currency >= hat1Cost;
            if (hat1BuyButton) hat1BuyButton.SetActive(canAfford1);
            if (hat1Image) hat1Image.color = canAfford1 ? Color.white : new Color(0.4f, 0.4f, 0.4f, 1f);
        }
        else
        {
            if (hat1BuyButton) hat1BuyButton.SetActive(false);
            if (hat1Image) hat1Image.color = Color.white;
        }

        if (!litterScript.hat2Bought)
        {
            bool canAfford2 = litterScript.Currency >= hat2Cost;
            if (hat2BuyButton) hat2BuyButton.SetActive(canAfford2);
            if (hat2Image) hat2Image.color = canAfford2 ? Color.white : new Color(0.4f, 0.4f, 0.4f, 1f);
        }
        else
        {
            if (hat2BuyButton) hat2BuyButton.SetActive(false);
            if (hat2Image) hat2Image.color = Color.white;
        }

        if (!litterScript.hat3Bought)
        {
            bool canAfford3 = litterScript.Currency >= hat3Cost;
            if (hat3BuyButton) hat3BuyButton.SetActive(canAfford3);
            if (hat3Image) hat3Image.color = canAfford3 ? Color.white : new Color(0.4f, 0.4f, 0.4f, 1f);
        }
        else
        {
            if (hat3BuyButton) hat3BuyButton.SetActive(false);
            if (hat3Image) hat3Image.color = Color.white;
        }
    }

    //buying functions
    public void buyItem1()
    {
        if (litterScript.Currency >= hat1Cost && !litterScript.hat1Bought)
        {
            litterScript.Currency -= hat1Cost;
            litterScript.currencyText.text = litterScript.Currency.ToString();
            litterScript.hat1Bought = true;
            if (goggles3DModel) goggles3DModel.SetActive(true);
        }
        UpdateShop();
    }

    public void buyItem2()
    {
        if (litterScript.Currency >= hat2Cost && !litterScript.hat2Bought)
        {
            litterScript.Currency -= hat2Cost;
            litterScript.currencyText.text = litterScript.Currency.ToString();
            litterScript.hat2Bought = true;
            if (kilt3DModel) kilt3DModel.SetActive(true);
        }
        UpdateShop();
    }

    public void buyItem3()
    {
        if (litterScript.Currency >= hat3Cost && !litterScript.hat3Bought)
        {
            litterScript.Currency -= hat3Cost;
            litterScript.currencyText.text = litterScript.Currency.ToString();
            litterScript.hat3Bought = true;
            if (hat3DModel) hat3DModel.SetActive(true);
        }
        UpdateShop();
    }

    //toggling accessories on and off
    public void toggleGoggles()
    {
        if (!litterScript.hat1Bought) return;
        gogglesOn = !gogglesOn;
        if (gogglesOnPenguin) gogglesOnPenguin.SetActive(gogglesOn);
        if (goggles3DModel) goggles3DModel.SetActive(gogglesOn);
    }

    public void toggleKit()
    {
        if (!litterScript.hat2Bought) return;
        kiltOn = !kiltOn;
        if (kiltOnPenguin) kiltOnPenguin.SetActive(kiltOn);
        if (kilt3DModel) kilt3DModel.SetActive(kiltOn);
    }

    public void toggleHat()
    {
        if (!litterScript.hat3Bought) return;
        hatOn = !hatOn;
        if (hatOnPenguin) hatOnPenguin.SetActive(hatOn);
        if (hat3DModel) hat3DModel.SetActive(hatOn);
    }

    public void accessoryOff()
    {
        gogglesOn = false;
        kiltOn = false;
        hatOn = false;
        if (gogglesOnPenguin) gogglesOnPenguin.SetActive(false);
        if (kiltOnPenguin) kiltOnPenguin.SetActive(false);
        if (hatOnPenguin) hatOnPenguin.SetActive(false);
        if (goggles3DModel) goggles3DModel.SetActive(false);
        if (kilt3DModel) kilt3DModel.SetActive(false);
        if (hat3DModel) hat3DModel.SetActive(false);
    }
}