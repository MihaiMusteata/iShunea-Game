using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
     public static PlayerHealthManager instance;
     public PlayerHealthManager(){}
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
     public void TakeDamage(int damage)
     {
         currentHP -= damage;
         Debug.Log("-10 damage!!!");
         GameEventsManager.instance.playerEvents.PlayerHealthChange(currentHP);

         if (currentHP <= 0)
         {
             // Jucătorul a murit, poți adăuga aici orice logică ai nevoie pentru a gestiona moartea jucătorului
             Debug.Log("Player died!");
             // De obicei, ar fi bine să dezactivezi jucătorul sau să încarci o scenă de game over
         }
     }
}
