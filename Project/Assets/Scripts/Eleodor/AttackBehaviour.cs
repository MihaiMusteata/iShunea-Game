/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    Transform botTransform;
    private NavMeshAgent agent;
    public int damage = 10; // Dauna cauzată de sabie
    public int maxHealth = 100;
    private int currentHealth;
    public Animator Animator;
    float timer;
    Transform initialTransform;
   // NavMeshAgent agent;
    float chaseRange = 5;
    public Vector3 initialPosition;
    //Collision collider;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();

        botTransform = animator.transform; 
        Animator = animator;
        //collider = animator.GetComponent<Collision>();
        currentHealth = maxHealth;
        initialTransform = GameObject.FindGameObjectWithTag("Points").transform;
        //timer = 0;
        //agent.SetDestination(initialTransform.position);
        //initialPosition = agent.transform.position;
        //agent.SetDestination(initialPosition);
        //Debug.Log("ONE STATE ENTER 83");
    }
     
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //cooldownScript.StartCooldown();

        agent.SetDestination(player.position);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > 3)
            animator.SetBool("IsAttacking01", false);

        if (distance > 15 || distance < 2)
        {
            animator.SetBool("IsRunning", false); 
        }
        //OnCollisionEnter(collider);
    }
 
    
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
 

  

    public void TakeDamage(int damage)
    {
        Debug.Log("damage -20 enemy");
        Debug.Log("Enemie health: "+currentHealth);
        currentHealth -= damage;
        Animator.SetBool("IsAttacking01", false);
        Animator.SetBool("Damage", true);
        if (currentHealth <= 0)
        {

            // Jucătorul a murit, poți adăuga aici orice logică ai nevoie pentru a gestiona moartea jucătorului
            Debug.Log("Enemy died!");
            // De obicei, ar fi bine să dezactivezi jucătorul sau să încarci o scenă de game over
        }
    }
   
}
  */