using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour, IDataPersistence
{
     [SerializeField] private string id;
     [ContextMenu("Generate guid for id")]
     private void GenerateGuid()
     {
          id = System.Guid.NewGuid().ToString();
     }

     [Header("Config")]
     [SerializeField] private int experienceGained = 25;

     private bool collected = false;

     private void CollectGem()
     {
          GameEventsManager.instance.playerEvents.ExperienceGained(experienceGained);
          GameEventsManager.instance.miscEvents.GemCollected();
          Destroy(gameObject);
          collected = true;
     }

     private void OnTriggerEnter(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               CollectGem();
          }
     }

     public void LoadData(GameData data)
     {
          data.gemsCollected.TryGetValue(id, out collected);
          if (collected)
          {
               gameObject.SetActive(false);
          }
     }

     public void SaveData(GameData data)
     {
          if (data.gemsCollected.ContainsKey(id))
          {
               data.gemsCollected.Remove(id);
          }
          data.gemsCollected.Add(id, collected);
     }
}
