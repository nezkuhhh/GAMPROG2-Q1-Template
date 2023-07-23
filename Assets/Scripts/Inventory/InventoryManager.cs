using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player player;

    [SerializeField]
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null
        ;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public void UseItem(ItemData data)
    {
        if (data.type == ItemType.Consumable)
        {
            player.AddAttributes(data.attributes);
        }
        else if (data.type == ItemType.Equipabble)
        {
            player.AddAttributes(data.attributes);
            equipmentSlots[GetEquipmentSlot(data.slotType)].SetItem(data);
        }
    }

   
    public void AddItem(string itemID)
    {
        for (int i = 0; i <= itemDatabase.Count; i++)
        {
            if (GetEmptyInventorySlot() != -1)
            {
                if (itemDatabase[i].id == itemID)
                {
                    inventorySlots[GetEmptyInventorySlot()].SetItem(itemDatabase[i]);
                    break;
                }
            }

        }
    }

    public int GetEmptyInventorySlot()
    {
        int temp = -1;
        for (int i = 0; i <= inventorySlots.Count - 1; i++)
        {
            if (!inventorySlots[i].HasItem())
            {
                temp = i;
                break;
            }
        }
        return temp;
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        //TODO
        //Check which equipment slot matches the slot type and return its index
        int temp = -1;
        for (int i = 0; i <= equipmentSlots.Count - 1; i++)
        {
            if (equipmentSlots[i].type == type)
            {
                if (!equipmentSlots[i].HasItem())
                {
                    temp = i;
                    break;
                }
            }
        }

        return temp;
    }
}
