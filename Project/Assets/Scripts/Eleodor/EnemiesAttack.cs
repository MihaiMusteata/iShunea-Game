using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10; // Dauna cauzată de inamic
    private bool canDamage = true; // Pentru a evita repetarea daunelor

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Verificăm dacă inamicul a lovit jucătorul (poate folosi un tag sau strat pentru jucător)
        if (hit.collider.CompareTag("Player") && canDamage)
        {
            Debug.Log("HIT!!!");
            // Obținem componenta "PlayerHealth" a jucătorului
            PlayerHealthManager playerHealth = gameObject.GetComponent<PlayerHealthManager>();

            // Verificăm dacă am găsit componenta "PlayerHealth"
            if (playerHealth != null)
            {
                // Apelăm metoda "TakeDamage" a jucătorului pentru a-i cauza daune
                playerHealth.TakeDamage(damage);

                // Setăm canDamage pe false pentru a evita repetarea daunelor în aceeași coliziune
                canDamage = false;
            }
        }
    }

    // Poți adăuga alte metode sau logică pentru comportamentul inamicului aici
}
