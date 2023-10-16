using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDataPersistence
{
     [SerializeField] GameObject restartGame;
     public static PlayerHealthManager instance;
     public PlayerHealthManager() { }
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
          if (currentHP <= 0)
          {
               restartGame.SetActive(true);
          }
          GameEventsManager.instance.playerEvents.PlayerHealthChange(currentHP);
     }
     //public void TakeDamage(int damage)
     //{
     //     currentHP -= damage;
     //     // Debug.Log("-10 damage!!!");
     //     GameEventsManager.instance.playerEvents.PlayerHealthChange(currentHP);

     //     if (currentHP <= 0)
     //     {
     //          restartGame.SetActive(true);
     //     }
     //}

     public void SaveData(GameData data)
     {
          data.currentHP = currentHP;
          if(currentHP <= 0)
          {
               data.gameOver = true;
          }
     }

     public void LoadData(GameData data)
     {
          //currentHP = data.currentHP;
     }
}
