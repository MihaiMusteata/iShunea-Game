using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour
{
     [Header("Config")]
     [SerializeField] private float respawnTimeSeconds = 2;
     [SerializeField] private int experienceGained = 25;
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

     private void CollectGem()
     {
          GameEventsManager.instance.playerEvents.ExperienceGained(experienceGained);
          GameEventsManager.instance.miscEvents.GemCollected();
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
               CollectGem();
          }
     }
}
