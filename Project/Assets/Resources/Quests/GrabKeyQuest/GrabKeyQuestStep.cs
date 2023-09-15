using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyQuestStep : QuestStep
{
     private void Update()
     {
          KeyGrabbed();
     }
     public bool ContainsItemWithName(string itemNameToCheck)
     {
          Item item = InventoryManager.instance.items.Find(i => i.itemName == itemNameToCheck);

          return item != null;
     }

     private void KeyGrabbed()
     {
          if (ContainsItemWithName("WizardTowerKey"))
          {
               FinishQuestStep();
          }
     }
     protected override void SetQuestStepState(string state)
     {
     }
}
