using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        if (InventoryManager.Instance.GetEmptyInventorySlot() != -1)
        {
            InventoryManager.Instance.AddItem(id);

            Destroy(this.gameObject);
        }
    }
}
