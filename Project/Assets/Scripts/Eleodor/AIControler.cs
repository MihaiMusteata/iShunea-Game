using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AIController : MonoBehaviour
{
    
     Transform player;
    Transform botTransform;
    private NavMeshAgent agent;
    public int damage = 10; // Dauna cauzată de sabie
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    float timer;
    Transform initialTransform;
    float chaseRange = 5;
    public Vector3 initialPosition;
    float attackRange = 3;
    private CharacterController characterController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = GetComponent<CharacterController>();

        agent = GetComponent<NavMeshAgent>();

        botTransform = transform; 
        animator = GetComponent<Animator>();
        //collider = GetComponent<Collision>();
        currentHealth = maxHealth;
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialTransform = GameObject.FindGameObjectWithTag("Points").transform;
        initialPosition = transform.position;
    }
    
    private void Update() 
    {
        if(animator.GetBool("IsWalking"))
        {
            //agent.SetDestination(initialTransform.position);
            agent.speed = 2; 
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < chaseRange && distance > 2)
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
                //SetBool("IsWalking", true);
                
            }
            float distance2 = Vector3.Distance(transform.position, initialTransform.position);


            if(distance2 < 1)
            {
                animator.SetBool("IsWalking", false); 
            }
        }
        if(animator.GetBool("IsRunning"))
        {
            float distance = Vector3.Distance(transform.position, player.position);

            agent.SetDestination(player.position);
            if (distance <= attackRange)
            {
                animator.SetBool("IsAttacking01", true);
                //SetBool("IsRunning", false);
            }


            //float distance2 = Vector3.Distance(transform.position, initialTransform.position);
            if (distance < 2)
            {

                animator.SetBool("IsRunning", false);
                //SetBool("IsWalking", true);
                //agent.SetDestination(initialPosition);

            }
            if(distance > chaseRange)
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsWalking", true);

            }
        }
        if(animator.GetBool("IsAttacking01"))
        {
            agent.SetDestination(player.position);
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > 2)
                animator.SetBool("IsAttacking01", false);

            if (distance > 15 || distance < 2)
            {
                animator.SetBool("IsRunning", false); 
            }
        }  
        if(animator.GetBool("Damage"))
        {
            Debug.Log("damage -20 enemy");
            Debug.Log("Enemie health: "+currentHealth);
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Debug.Log("Enemy died!");
            }
        }
        else 
        {
            float distance = Vector3.Distance(this.transform.position, player.position);
            if (distance < chaseRange && distance > 2)
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsWalking", false);
            }
        }   
        //CheckCollisions();

    }
    private IEnumerator PauzaDupaAnimatie()
    {
        // Așteptați o secundă
        yield return new WaitForSeconds(50.0f);
    }
   /*  void CheckCollisions()
    {
        // Obținem extremitățile Character Controller-ului
        //Vector3 bottom = transform.position - characterController.height / 2 * Vector3.up;
        //Vector3 top = transform.position + characterController.height / 2 * Vector3.up;

        // Verificăm coliziunile cu obiectele care au tag-ul "SpamPlane"
        //Collider[] hitColliders = Physics.OverlapCapsule(bottom, top, characterController.radius);
        Collider collider;
        
            
        
    } */
   /*  void OnCollisionEnter(Collider colider)
    {
            if (colider.CompareTag("PlayerSword"))
            {
                Debug.Log("ceva");
                animator.SetBool("Damage", true);
                StartCoroutine(PauzaDupaAnimatie());
            }
            else
            {
                animator.SetBool("Damage", false);
            }
    } */
    
       /*  public void TakeDamage(int damage)
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
        } */
 
}