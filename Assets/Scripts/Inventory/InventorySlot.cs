using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        itemIcon.enabled = true;
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = data.icon;
        itemData = data;
    }

    public void UseItem()
    {
        if (itemData.type == ItemType.Equipabble)
        {
            if (InventoryManager.Instance.GetEquipmentSlot(itemData.slotType) > 0)
            {
                InventoryManager.Instance.UseItem(itemData);
                itemIcon.gameObject.SetActive(false);
                itemData = null;
                itemIcon.sprite = null;
            }
        }
        else
        {
            InventoryManager.Instance.UseItem(itemData);
            itemIcon.gameObject.SetActive(false);
            itemData = null;
            itemIcon.sprite = null;
        }
        // TODO
        // Reset the item data and the icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}