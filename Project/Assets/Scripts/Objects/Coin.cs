using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IDataPersistence
{
     [SerializeField] private string id;
     [ContextMenu("Generate guid for id")]
     private void GenerateGuid()
     {
          id = System.Guid.NewGuid().ToString();
     }

     [Header("Config")]
     [SerializeField] private int goldGained = 1;
     
     private bool collected = false;

     private void CollectCoin()
     {
          GameEventsManager.instance.goldEvents.GoldGained(goldGained);
          GameEventsManager.instance.miscEvents.CoinCollected();
          Destroy(gameObject);
          collected = true;
     }

     private void OnTriggerEnter(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               CollectCoin();
          }
     }


     public void LoadData(GameData data)
     {
          data.coinsCollected.TryGetValue(id, out collected);
          if (collected)
          {
               gameObject.SetActive(false);
          }
     }

     public void SaveData(GameData data)
     {
          if (data.coinsCollected.ContainsKey(id))
          {
               data.coinsCollected.Remove(id);
          }
          data.coinsCollected.Add(id, collected);
     }
}
