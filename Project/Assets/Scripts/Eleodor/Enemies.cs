using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    /* public int damage = 10; // Dauna cauzată de sabie
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
   
    private void OnCollisionEnter(Collision collision)
    {
        // Verificăm dacă obiectul lovit are un tag "Enemy"
        if (collision.gameObject.CompareTag("PlayerSword"))
        {
            // Obținem componenta "Enemy" atașată obiectului lovit
            //Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // Verificăm dacă am găsit componenta "Enemy"
           
                // Apelăm metoda "TakeDamage" a inamicului pentru a-i cauza dauna
                TakeDamage(damage);
            
        }
    }
 

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("damage -10 enemy");
        Debug.Log("Enemie health: "+currentHealth);
        currentHealth -= damage;
        animator.SetBool("IsAttacking01", false);
        animator.SetBool("Damage", true);
        if (currentHealth <= 0)
        {

            // Jucătorul a murit, poți adăuga aici orice logică ai nevoie pentru a gestiona moartea jucătorului
            Debug.Log("Enemy died!");
            // De obicei, ar fi bine să dezactivezi jucătorul sau să încarci o scenă de game over
        }
    } */
}

