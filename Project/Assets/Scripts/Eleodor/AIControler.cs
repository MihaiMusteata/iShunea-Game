using UnityEngine;
using UnityEngine.AI;

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
   // NavMeshAgent agent;
    float chaseRange = 5;
    public Vector3 initialPosition;
    float attackRange = 3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

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
           animator.SetBool("IsIdle", true);
           Debug.Log("Animator = "+animator.GetBool("IsIdle"));
        if(animator.GetBool("IsIdle"))
        {
                timer += Time.deltaTime;
            //if (timer > 5)
               // SetBool("isPatrolling", true);
            Debug.Log("IS IDLE!!");
            float distance = Vector3.Distance(this.transform.position, player.position);
            if (distance < chaseRange && distance > 2)
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsWalking", false);
                transform.LookAt(player);
            }
        }
        if(animator.GetBool("IsWalking"))
        {
            agent.SetDestination(initialTransform.position);
            agent.speed = 2; 
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < chaseRange && distance > 2)
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
                transform.LookAt(player);
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
            transform.LookAt(player.position);
            // Debug.Log("distance = "+ distance);
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
            if (distance > 3)
                animator.SetBool("IsAttacking01", false);

            if (distance > 15 || distance < 2)
            {
                animator.SetBool("IsRunning", false); 
            }
        }        
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
            animator.SetBool("IsAttacking01", false);
            animator.SetBool("Damage", true);
            if (currentHealth <= 0)
            {

                // Jucătorul a murit, poți adăuga aici orice logică ai nevoie pentru a gestiona moartea jucătorului
                Debug.Log("Enemy died!");
                // De obicei, ar fi bine să dezactivezi jucătorul sau să încarci o scenă de game over
            }
        }
 
}
 
 /* 
 using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private Transform player;
    private Transform botTransform;
    private NavMeshAgent agent;
    public int damage = 10; // Dauna cauzată de sabie
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    private float chaseRange = 5;
    private Vector3 initialPosition;
    private float attackRange = 3;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        botTransform = transform;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        initialPosition = transform.position;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseRange && distance > attackRange)
        {
            // Urmează jucătorul
            agent.SetDestination(player.position);

            // Face față jucătorului
            transform.LookAt(player.position);

            if (distance <= attackRange)
            {
                // Dacă e la distanță de atac, declanșează animația de atac
                animator.SetBool("IsAttacking01", true);
            }
            else
            {
                // Dacă nu e la distanță de atac, oprește animația de atac
                animator.SetBool("IsAttacking01", false);
            }
        }

        // Restul codului pentru starea "IsIdle", "IsWalking" și "IsRunning" poate rămâne în funcțiile corespunzătoare Animatorului și
        // ar trebui să fie gestionat în Animator Controller.

        // Restul codului pentru gestionarea stării de daună trebuie să rămână neschimbat.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerSword"))
        {
            // Dacă inamicul este lovit de sabie
            TakeDamage(damage);
        }
    }

    private void TakeDamage(int damage)
    {
        // Cauzează daună inamicului
        currentHealth -= damage;
        animator.SetBool("Damage", true);

        if (currentHealth <= 0)
        {
            // Inamicul a murit
            Debug.Log("Enemy died!");
            // Aici poți adăuga logica pentru când inamicul moare
            Destroy(gameObject); // De exemplu, poți distruge inamicul sau să îl dezactivezi
        }
    }
}
 */