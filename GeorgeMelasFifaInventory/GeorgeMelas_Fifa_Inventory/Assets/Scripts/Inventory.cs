using UnityEngine;
using System.Collections;
// Using generic lists
using System.Collections.Generic;
//Using Unity's UI
using UnityEngine.UI;

// Create a slot class to store it's gameobject and item within.
public class SlotData
{
    public GameObject gameObject;
    public ItemData itemData;

    public SlotData(GameObject gameObject, ItemData itemData)
    {
        this.gameObject = gameObject;
        this.itemData = itemData;
    }
}

[System.Serializable]
public class ItemInfo
{
    public int id;
    public int amount;
}

[RequireComponent(typeof(ItemDatabase))]

public class Inventory : MonoBehaviour
{
    // public 
    [Header("UI")]
    public int slotAmount = 20;
    public GameObject slotPanel;
    [Header("Prefabs")]
    public GameObject slotPrefab;
    public GameObject itemPrefab;

    [Header("Item/Slots")]

    public List<ItemData> items = new List<ItemData>();
    public List<SlotData> slots = new List<SlotData>();

    //Private
    private ItemDatabase database;
    // Use this for initialization
    void Start()
    {
        // Get the Item database
        database = GetComponent<ItemDatabase>();

        // Loop through by the slot amount
        for (int i = 0; i < slotAmount; i++)
        {
            //Create all the slots under slotPanel
            GameObject clone = Instantiate(slotPrefab);
            clone.transform.SetParent(slotPanel.transform);

            // Create a new empty slots for our inventory
            SlotData slotData = new SlotData(clone, null);



            // Gets new slots to the list
            Slot slot = clone.GetComponent<Slot>();
            slot.inventory = this;
            slot.data = slotData;



            // Add Slot to the list

            slots.Add(slotData);
        }

        AddItems();


    }

    void AddItems()
    {
        #region ItemById            
        AddItemById(0, 1);
        AddItemById(1, 1);
        AddItemById(2, 1);
        AddItemById(3, 1);
        AddItemById(4, 1);
        AddItemById(5, 1);
        AddItemById(6, 1);
        AddItemById(7, 1);
        AddItemById(8, 1);
        AddItemById(9, 1);
        AddItemById(10, 1);
        AddItemById(11, 1);
        AddItemById(12, 1);
        AddItemById(13, 1);
        AddItemById(14, 1);
        AddItemById(15, 1);
        AddItemById(16, 1);
        AddItemById(17, 1);
        AddItemById(18, 1);
        AddItemById(19, 1);
        AddItemById(20, 1);
        AddItemById(21, 1);
        AddItemById(22, 1);
        AddItemById(23, 1);
        AddItemById(24, 1);
        AddItemById(25, 1);
        AddItemById(26, 1);
        AddItemById(27, 1);
        AddItemById(28, 1);
        AddItemById(29, 1);
        AddItemById(30, 1);
        AddItemById(31, 1);
        AddItemById(32, 1);
        AddItemById(33, 1);
        AddItemById(34, 1);
        AddItemById(35, 1);
        AddItemById(36, 1);
        AddItemById(37, 1);
        AddItemById(38, 1);
        AddItemById(39, 1);
        AddItemById(40, 1);
        #endregion
    }
    
    public void AddItemById(int id, int itemAmount = 1)
    {
        // Get an item from database by id
        ItemData newItem = database.GetItemById(id);

        // Get an empty slot in our inventory
        SlotData newSlot = GetEmptySlot();

        // Check if newItem AND newSlot is not Null
        if(newItem != null && newSlot != null)
        {
            // Set the empty slot
            newSlot.itemData = newItem;

            // Create a new item instance
            GameObject itemGameObject;
            if (itemPrefab != null)
            {
                itemGameObject = Instantiate(itemPrefab);
            }
            else
            {
                itemGameObject = new GameObject();
            }

            itemGameObject.transform.position = newSlot.gameObject.transform.position;

            // Sets it's parent in the hierarchy
            itemGameObject.transform.SetParent(newSlot.gameObject.transform);
            itemGameObject.name = newItem.Title;

            // Set the items gameobject
            newItem.gameobject = itemGameObject;

            // Get the image component of that item and set it
            Image image = itemGameObject.GetComponent<Image>();
            image.sprite = newItem.sprite;


            // Get the item component and set it
            Item item = itemGameObject.GetComponent<Item>();
            item.data = newItem;
            item.slotData = newSlot;
        
        }
    }


    public SlotData GetEmptySlot()
    {
        // Loop through all of our slots

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemData == null)
            {
                // Return that slot
                return slots[i];
            }
        }

        // otherwise,no empty slots were found
        print("No empty slots found!");
        return null;
    }

    bool HasStacked(ItemData itemToAdd, int itemAmount = 1)
    {
        // Check if item is stackable
        if (itemToAdd.Stackable)
        {
            // Check if a slot already has item in inventory
            SlotData occupiedSlot = GetSlotDataWithItemData(itemToAdd);
            if (occupiedSlot != null)
            {
                // Increase the items "Amount" Variable for text
                ItemData itemData = occupiedSlot.itemData;
                Item item = itemData.gameobject.gameObject.GetComponent<Item>();
                item.amount += itemAmount;
                return true;
            }
        }
        return false;
    }
    SlotData GetSlotDataWithItemData(ItemData item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            ItemData currentItem = slots[i].itemData;
            if (currentItem != null && currentItem.Id == item.Id)
            {
                return slots[i];
            }
        }
        return null;
    }

}
