using UnityEngine;

public class PlayerIsNear : MonoBehaviour
{
     [Header("Target")]
     [SerializeField] private GameObject objectTarget;
     [SerializeField] private string objectType;
     public bool isInactive = false;
     private void Update()
     {
          switch (objectType)
          {
               case "QuestIcon":
                    UpdateQuestIcon();
                    break;
               case "Object":
                    UpdateObject();
                    break;
          }


     }
     public void UpdateQuestIcon()
     {
          if (!isInactive)
          {
               bool stateIsSet = objectTarget.GetComponent<QuestIcon>().stateIsSet;
               if (stateIsSet)
               {
                    objectTarget.SetActive(false);
                    isInactive = true;
               }
          }
     }

     private void UpdateObject()
     {
          if (!isInactive)
          {
               objectTarget.SetActive(false);
               isInactive = true;
          }
     }
     private void OnTriggerEnter(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               objectTarget.SetActive(true);
          }
     }

     private void OnTriggerExit(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               objectTarget.SetActive(false);
          }
     }
}
