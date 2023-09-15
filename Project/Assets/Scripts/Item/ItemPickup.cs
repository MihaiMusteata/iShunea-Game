using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
     public Item item;

     private void Pickup()
     {
          InventoryManager.instance.AddItem(item);
          Destroy(gameObject);
     }

     private void OnMouseDown()
     {
          Pickup();
     }
}
