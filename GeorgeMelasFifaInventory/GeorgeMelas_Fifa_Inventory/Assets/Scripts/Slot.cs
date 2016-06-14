using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public SlotData data;
    public Inventory inventory;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedGameobject = eventData.pointerDrag;
        Item droppedItem = droppedGameobject.GetComponent<Item>();


        //Is the Slot empty?
        if (data.itemData == null)
        {
            //Move the dropped item into this slot
            droppedItem.slotData.itemData = null;
            droppedItem.slotData = data;
        }
        else //The Slot is not empty
        {
            // Get the current item that occupies the slot
            GameObject currentItem = data.itemData.gameobject;
            //Get the item script attached to that item
            Item item = currentItem.GetComponent<Item>();
            //Set the item's slot to the dropped item's slot
            item.slotData = droppedItem.slotData;

            // Set the parent of the current item to the dropped item.
            item.transform.SetParent(droppedItem.slotData.gameObject.transform);
            // Set the Position of item to new parent
            item.transform.position = droppedItem.slotData.gameObject.transform.position;

            // Set value inside of dropped item

            // Set slot to new slot
            droppedItem.slotData = data;
            // Set parent to new parent
            droppedItem.transform.SetParent(transform);
            // Set position to the new position
            droppedItem.transform.position = transform.position;
        }
    }
}
