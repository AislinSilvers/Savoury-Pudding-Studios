using UnityEngine;
using UnityEngine.UI;

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
    public Image hat1Image;
    public Image hat2Image;
    public Image hat3Image;

    [Header("Costs")]
    public int hat1Cost = 20;
    public int hat2Cost = 25;
    public int hat3Cost = 30;

    private int equippedItem = 0;

    //buying items variables
    public rubbishCollection litterScript;

    void Start()
    {
        litterScript = GameObject.Find("Player").GetComponent<rubbishCollection>();

        if (inventoryShopPanel) inventoryShopPanel.SetActive(false);
        if (inventoryButton) inventoryButton.SetActive(true);

        EquipItem(0);

        if (hat1BuyButton) hat1BuyButton.SetActive(false);
        if (hat2BuyButton) hat2BuyButton.SetActive(false);
        if (hat3BuyButton) hat3BuyButton.SetActive(false);

        UpdateShop();
    }

    void Update()
    {
        UpdateShop();
    }

    void EquipItem(int item)
    {
        if (gogglesOnPenguin) gogglesOnPenguin.SetActive(false);
        if (kiltOnPenguin) kiltOnPenguin.SetActive(false);
        if (hatOnPenguin) hatOnPenguin.SetActive(false);
        if (goggles3DModel) goggles3DModel.SetActive(false);
        if (kilt3DModel) kilt3DModel.SetActive(false);
        if (hat3DModel) hat3DModel.SetActive(false);

        equippedItem = item;

        if (item == 1)
        {
            if (gogglesOnPenguin) gogglesOnPenguin.SetActive(true);
            if (goggles3DModel) goggles3DModel.SetActive(true);
        }
        else if (item == 2)
        {
            if (kiltOnPenguin) kiltOnPenguin.SetActive(true);
            if (kilt3DModel) kilt3DModel.SetActive(true);
        }
        else if (item == 3)
        {
            if (hatOnPenguin) hatOnPenguin.SetActive(true);
            if (hat3DModel) hat3DModel.SetActive(true);
        }
    }

    //toggling inventory panel open and closed
    public void ToggleInventory()
    {
        if (inventoryShopPanel)
        {
            bool isOpen = !inventoryShopPanel.activeSelf;
            inventoryShopPanel.SetActive(isOpen);

            // Keep button always visible
            if (inventoryButton) inventoryButton.SetActive(true);
        }
    }

    void UpdateShop()
    {
        if (litterScript == null) return;

        if (!litterScript.hat1Bought)
        {
            bool canAfford1 = litterScript.Currency >= hat1Cost;
            if (hat1BuyButton) hat1BuyButton.SetActive(canAfford1);
            if (hat1Image)
            {
                hat1Image.color = canAfford1 ? Color.white : new Color(0.4f, 0.4f, 0.4f, 1f);
                hat1Image.GetComponent<Button>()?.onClick.RemoveAllListeners();
            }
        }
        else
        {
            if (hat1BuyButton) hat1BuyButton.SetActive(false);
            if (hat1Image)
            {
                hat1Image.color = Color.white;
                Button btn = hat1Image.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(toggleGoggles);
                }
            }
        }

        if (!litterScript.hat2Bought)
        {
            bool canAfford2 = litterScript.Currency >= hat2Cost;
            if (hat2BuyButton) hat2BuyButton.SetActive(canAfford2);
            if (hat2Image)
            {
                hat2Image.color = canAfford2 ? Color.white : new Color(0.4f, 0.4f, 0.4f, 1f);
                hat2Image.GetComponent<Button>()?.onClick.RemoveAllListeners();
            }
        }
        else
        {
            if (hat2BuyButton) hat2BuyButton.SetActive(false);
            if (hat2Image)
            {
                hat2Image.color = Color.white;
                Button btn = hat2Image.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(toggleKit);
                }
            }
        }

        if (!litterScript.hat3Bought)
        {
            bool canAfford3 = litterScript.Currency >= hat3Cost;
            if (hat3BuyButton) hat3BuyButton.SetActive(canAfford3);
            if (hat3Image)
            {
                hat3Image.color = canAfford3 ? Color.white : new Color(0.4f, 0.4f, 0.4f, 1f);
                hat3Image.GetComponent<Button>()?.onClick.RemoveAllListeners();
            }
        }
        else
        {
            if (hat3BuyButton) hat3BuyButton.SetActive(false);
            if (hat3Image)
            {
                hat3Image.color = Color.white;
                Button btn = hat3Image.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(toggleHat);
                }
            }
        }
    }

    //buying functions
    public void buyItem1()
    {
        if (litterScript.Currency >= hat1Cost && !litterScript.hat1Bought)
        {
            litterScript.Currency -= hat1Cost;
            litterScript.UpdateCurrencyText();
            litterScript.hat1Bought = true;
            EquipItem(1);
        }
        UpdateShop();
    }

    public void buyItem2()
    {
        if (litterScript.Currency >= hat2Cost && !litterScript.hat2Bought)
        {
            litterScript.Currency -= hat2Cost;
            litterScript.UpdateCurrencyText();
            litterScript.hat2Bought = true;
            EquipItem(2);
        }
        UpdateShop();
    }

    public void buyItem3()
    {
        if (litterScript.Currency >= hat3Cost && !litterScript.hat3Bought)
        {
            litterScript.Currency -= hat3Cost;
            litterScript.UpdateCurrencyText();
            litterScript.hat3Bought = true;
            EquipItem(3);
        }
        UpdateShop();
    }

    //toggling accessories on and off
    public void toggleGoggles()
    {
        if (!litterScript.hat1Bought) return;
        if (equippedItem == 1) EquipItem(0);
        else EquipItem(1);
    }

    public void toggleKit()
    {
        if (!litterScript.hat2Bought) return;
        if (equippedItem == 2) EquipItem(0);
        else EquipItem(2);
    }

    public void toggleHat()
    {
        if (!litterScript.hat3Bought) return;
        if (equippedItem == 3) EquipItem(0);
        else EquipItem(3);
    }

    public void accessoryOff()
    {
        EquipItem(0);
    }
}