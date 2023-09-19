using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("-10 damage!!!");

        if (currentHealth <= 0)
        {
            // Jucătorul a murit, poți adăuga aici orice logică ai nevoie pentru a gestiona moartea jucătorului
            Debug.Log("Player died!");
            // De obicei, ar fi bine să dezactivezi jucătorul sau să încarci o scenă de game over
        }
    }
}
