/* 
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    private Animator animator;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        animator.SetBool("IsWalking",true);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
 */

/* using UnityEngine;
using UnityEngine.AI;

public class AIControler : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float attackRange = 2.0f;
    public float chaseRange = 10.0f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        if (navMeshAgent == null || animator == null)
        {
            Debug.LogError("Componentele NavMeshAgent sau Animator nu au fost găsite.");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                // Atacă jucătorul
                animator.SetBool("IsAttacking0" + Random.Range(1, 3), distanceToPlayer <= attackRange);
            }
            else if (distanceToPlayer <= chaseRange)
            {
                // Urmărește jucătorul
                navMeshAgent.SetDestination(player.position);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                // Stă pe loc dacă jucătorul este prea departe
                navMeshAgent.SetDestination(transform.position);
                animator.SetBool("IsWalking", false);
            }
        }
        else
        {
            Debug.LogError("Jucătorul nu a fost atașat la bot sau este nul.");
        }
    }
}
 */










/* 
 using UnityEngine;
using UnityEngine.AI;

public class AIControler : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float attackRange = 0.1f;
    public float chaseRange = 0.2f;
    public float returnRange = 1f;
    private Vector3 initialPosition;
    private bool isReturning = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (animator == null || navMeshAgent == null)
        {
            Debug.LogError("Componenta NavMeshAgent nu a fost găsită pe acest obiect.");
        }
       
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > chaseRange)
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsAttacking01", false);

                // Verificați dacă botul este deja în procesul de întoarcere
                if (!isReturning)
                {
                    // Dacă depășește distanța de returnare, începe să se întoarcă
                    if (Vector3.Distance(transform.position, initialPosition) > returnRange)
                    {
                        isReturning = true;
                        animator.SetBool("IsWalking", true);
                        navMeshAgent.SetDestination(initialPosition);
                    }
                    else
                    {
                            isReturning = false;
                            // Botul a ajuns la poziția inițială, activează Idle
                            animator.SetBool("IsIdle", true);
                            Debug.Log("Tebuie să își activeze IDLE animatie");
                           
                    }
                }
                else if (Vector3.Distance(transform.position, initialPosition) <= returnRange)
                {
                    // Botul a revenit la poziția inițială, dezactivează "Walking"
                    animator.SetBool("IsWalking", false);
                }
            }
            else
            {
                // Botul se află în raza de urmărire a jucătorului
                isReturning = false;
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalking", distanceToPlayer > attackRange);
                animator.SetBool("IsRunning", distanceToPlayer > chaseRange);
                animator.SetBool("IsAttacking0" + Random.Range(1, 3), distanceToPlayer <= attackRange);
                navMeshAgent.SetDestination(player.position);
            }
        }
        else
        {
            Debug.LogError("Nu a fost atașat jucătorul la script sau jucătorul este nul.");
        }
    }
}
 */
/* 
using UnityEngine;
using UnityEngine.AI;

public class AIControler : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float attackRange = 0.1f;
    public float chaseRange = 0.2f;
    public float returnRange = 1f;
    private Vector3 initialPosition;
    private enum BotState { Idle, Walking, Running, Attacking, Returning }
    private BotState currentState = BotState.Idle;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (animator == null || navMeshAgent == null)
        {
            Debug.LogError("Componenta NavMeshAgent sau Animator nu a fost găsită pe acest obiect.");
        }
       
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            switch (currentState)
            {
                case BotState.Idle:
                    animator.SetBool("IsIdle", true);
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsAttacking01", false);

                    if (distanceToPlayer <= chaseRange)
                    {
                        currentState = BotState.Running;
                        break;
                    }

                    if (Vector3.Distance(transform.position, initialPosition) > returnRange)
                    {
                        currentState = BotState.Returning;
                        navMeshAgent.SetDestination(initialPosition);
                    }
                    break;

                case BotState.Walking:
                    animator.SetBool("IsWalking", false);

                    // Setează starea animatorului pentru mers
                    break;

                case BotState.Running:
                    animator.SetBool("IsRunning", false);

                    // Setează starea animatorului pentru fugă
                    break;

                case BotState.Attacking:
                    animator.SetBool("IsAttacking0" + Random.Range(1, 3), distanceToPlayer <= attackRange);
                    // Setează starea animatorului pentru atac
                    break;

                case BotState.Returning:
                    if (Vector3.Distance(transform.position, initialPosition) <= returnRange)
                    {
                        // Botul a revenit la poziția inițială, activează Idle
                        currentState = BotState.Idle;
                    }
                    break;
            }
        }
        else
        {
            Debug.LogError("Jucătorul nu a fost atașat la script sau jucătorul este nul.");
        }
    }
}
 */using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float attackRange = 0.1f;
    public float chaseRange = 10.0f; // Am crescut raza de urmărire
    public float returnRange = 5.0f;
    private Vector3 initialPosition;
    private bool isReturning = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (animator == null || navMeshAgent == null)
        {
            Debug.LogError("Componenta NavMeshAgent sau Animator nu a fost găsită pe acest obiect.");
        }

        initialPosition = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > chaseRange)
            {
               /*  animator.SetBool("IsIdle", true); // Activează animația Idle
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsAttacking01", false); */

                // Verificați dacă botul este deja în procesul de întoarcere
                if (!isReturning)
                {
                    // Dacă depășește distanța de returnare, începe să se întoarcă
                    if (Vector3.Distance(transform.position, initialPosition) > returnRange)
                    {
                        Debug.Log("IsWalking == true (398)(if)");
                        isReturning = true;
                        animator.SetBool("IsWalking", true);
                        navMeshAgent.SetDestination(initialPosition);
                    }
                    else
                    {
                        Debug.Log("IsIdle == true (404)(else)");
                        isReturning = false;
                        // Botul a ajuns la poziția inițială, activează Idle
                        animator.SetBool("IsWalking", false);
                        animator.SetBool("IsIdle", true); // Activează animația Idle
                    }
                }
            }
            if(isReturning || Vector3.Distance(transform.position, initialPosition) > returnRange)
            {
                animator.SetBool("IsIdle", true);
            }
            else
            {
                // Botul se află în raza de urmărire a jucătorului
                isReturning = false;
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalking", distanceToPlayer > attackRange);
                animator.SetBool("IsRunning", distanceToPlayer > chaseRange);
                animator.SetBool("IsAttacking0" + Random.Range(1, 3), distanceToPlayer <= attackRange);
                navMeshAgent.SetDestination(player.position);
            }
        }
        else
        {
            Debug.LogError("Jucătorul nu a fost atașat la script sau jucătorul este nul.");
        }
    }
}
