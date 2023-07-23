using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    public EquipmentSlotType type;

    private ItemData itemData;
    
    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        // Make sure to apply the attributes once an item is equipped
        itemIcon.enabled = enabled;
        itemIcon.sprite = data.icon;
        itemIcon.gameObject.SetActive(true);
        defaultIcon.gameObject.SetActive(false);
        itemData = data;
    }

    public void Unequip()
    {
        // TODO
        // Check if there is an available inventory slot before removing the item.
        // Make sure to return the equipment to the inventory when there is an available slot.
        // Reset the item data and icons here
        if (InventoryManager.Instance.GetEmptyInventorySlot() <= InventoryManager.Instance.inventorySlots.Count)
        {
            if (InventoryManager.Instance.GetEmptyInventorySlot() != -1)
            {
                //undoes everything from the SetItem code
                InventoryManager.Instance.AddItem(itemData.id);
                InventoryManager.Instance.player.RemoveAttributes(itemData.attributes);
                itemIcon.enabled = false;
                itemIcon.gameObject.SetActive(false);
                itemIcon.sprite = null;
                defaultIcon.gameObject.SetActive(true);
                itemData = null;
            }
        }
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
