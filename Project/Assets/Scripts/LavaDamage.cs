using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
     [Header("Config")]
     [SerializeField] private int damage = 1;

     public float damageInterval = 1.0f;
     private float lastDamageTime = 0.0f;

     private bool isPlayerInLava = false;
     private void LateUpdate()
     {
          if (isPlayerInLava)
          {
               if (Time.time - lastDamageTime >= damageInterval)
               {
                    GameEventsManager.instance.playerEvents.HealthGained(-damage);
                    if (PlayerHealthManager.instance.currentHP > 0)
                    {
                         lastDamageTime = Time.time;
                    }
                    else
                    {
                         isPlayerInLava = false;
                    }
               }
          }
     }
     private void OnTriggerEnter(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               if(PlayerHealthManager.instance.currentHP > 0)
               {
                    isPlayerInLava = true;
               }
          }
     }

     private void OnTriggerExit(Collider otherCollider)
     {
          if (otherCollider.CompareTag("Player"))
          {
               isPlayerInLava = false;
          }
     }

}
