using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : StateMachineBehaviour
{
    public int damage = 10; // Dauna cauzată de sabie
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    Collision collider;
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
 

   /*  private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    } */

    public void TakeDamage(int damage)
    {
        Debug.Log("damage -20 enemy");
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
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator = animator.GetComponent<Animator>();
        collider = animator.GetComponent<Collision>();
        currentHealth = maxHealth;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnCollisionEnter(collider);
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
