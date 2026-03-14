using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryShopPanel;

    public void ToggleInventory()
    {
        inventoryShopPanel.SetActive(!inventoryShopPanel.activeSelf);
    }
}