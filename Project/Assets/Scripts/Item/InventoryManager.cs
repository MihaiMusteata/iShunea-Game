using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
     public static InventoryManager instance;
     public List<Item> items = new List<Item>();

     public Transform ItemContent;
     public GameObject InventoryItem;

     private void Awake()
     {
          instance = this;
     }

     public void AddItem(Item item)
     {
          items.Add(item);
     }

     public void RemoveItem(Item item)
     {
          items.Remove(item);
     }

     public void ListItems()
     {
          foreach(Transform item in ItemContent)
          {
               Destroy(item.gameObject);
          }

          foreach (var item in items)
          {
               GameObject newItem = Instantiate(InventoryItem, ItemContent);
               var itemName = newItem.transform.GetChild(0).GetComponent<Text>();
               var itemIcon = newItem.transform.GetChild(1).GetComponent<Image>();

               itemName.text = item.name;
               itemIcon.sprite = item.icon;
          }
     }
}
