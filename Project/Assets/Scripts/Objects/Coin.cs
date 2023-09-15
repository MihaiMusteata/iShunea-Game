using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
     [Header("Config")]
     [SerializeField] private float respawnTimeSeconds = 8;
     [SerializeField] private int goldGained = 1;
     [SerializeField] private bool respawn = false;

     private BoxCollider boxCollider;
     private Vector3 startingPosition;
     private MeshRenderer meshRenderer;

     private void Awake()
     {
          boxCollider = GetComponent<BoxCollider>();
          startingPosition = transform.position;
          meshRenderer = GetComponent<MeshRenderer>();
     }

     private void CollectCoin()
     {
          GameEventsManager.instance.goldEvents.GoldGained(goldGained);
          GameEventsManager.instance.miscEvents.CoinCollected();
          StopAllCoroutines();
          if (respawn)
          {
               StopAllCoroutines();
               StartCoroutine(RespawnAfterTime());
               boxCollider.enabled = false;
               meshRenderer.enabled = false;
          }
          else
          {
               Destroy(gameObject);
          }
     }

     private IEnumerator RespawnAfterTime()
     {
          yield return new WaitForSeconds(respawnTimeSeconds);
          transform.position = startingPosition;
          boxCollider.enabled = true;
          meshRenderer.enabled = true;
     }

     private void OnTriggerEnter(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               CollectCoin();
          }
     }
}
