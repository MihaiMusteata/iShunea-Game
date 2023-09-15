using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
     public static PlayerHealthManager instance;
     [Header("Configuration")]
     [SerializeField] private int startingHP = 100;

     public int currentHP;

     private void Awake()
     {
          currentHP = startingHP;
          instance = this;
     }

     private void OnEnable()
     {
          GameEventsManager.instance.playerEvents.onHealthGained += HealthGained;
     }

     private void OnDisable()
     {
          GameEventsManager.instance.playerEvents.onHealthGained -= HealthGained;
     }

     private void Start()
     {
          GameEventsManager.instance.playerEvents.PlayerHealthChange(currentHP);
     }

     private void HealthGained(int health)
     {
          currentHP += health;
          GameEventsManager.instance.playerEvents.PlayerHealthChange(currentHP);
     }
}
