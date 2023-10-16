using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
     [Header("Profile")]
     [SerializeField] private string profileId = "";

     [Header("Content")]
     [SerializeField] private GameObject noDataContent;
     [SerializeField] private GameObject hasDataContent;
     [SerializeField] public Text saveDate;

     [Header("Clear Data Button")]
     [SerializeField] private Button clearButton;

     public bool hasData { get; private set; } = false;

     private Button saveSlotButton;

     private void Awake()
     {
          saveSlotButton = this.GetComponent<Button>();
     }

     public void SetData(GameData data)
     {
          // there's no data for this profileId
          if (data == null)
          {
               hasData = false;
               noDataContent.SetActive(true);
               hasDataContent.SetActive(false);
               clearButton.gameObject.SetActive(false);

               //saveDate.text = "";
          }
          // there is data for this profileId
          else
          {
               if (data.gameOver)
               {
                    hasData = true;
                    noDataContent.SetActive(false);
                    hasDataContent.SetActive(true);
                    saveSlotButton.interactable = false;
                    clearButton.gameObject.SetActive(true);
                    saveDate.text = "Game Over";
               }
               else
               {
                    hasData = true;
                    noDataContent.SetActive(false);
                    hasDataContent.SetActive(true);
                    clearButton.gameObject.SetActive(true);
                    saveDate.text = data.lastUpdate;
               }
               
          }
     }

     public string GetProfileId()
     {
          return this.profileId;
     }

     public void SetInteractable(bool interactable)
     {
          saveSlotButton.interactable = interactable;
          clearButton.interactable = interactable;
     }
}
