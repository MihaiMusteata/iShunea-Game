/* using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    //List<Transform> points = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseRange = 10;
    Vector3 initialPosition;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        //Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        //foreach (Transform t in pointsObject)
         //   points.Add(t);
        agent = animator.GetComponent<NavMeshAgent>();
        initialPosition = agent.transform.position; 
        agent.SetDestination(initialPosition);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToInitialPosition = Vector3.Distance(agent.transform.position, initialPosition);

    // Dacă distanța depășește o anumită valoare (de exemplu, 5 unități), atunci botul se întoarce la poziția inițială
    if (distanceToInitialPosition > 5f)
    {
        agent.SetDestination(initialPosition);
    }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(initialPosition);
        }
           // agent.SetDestination(points[Random.Range(0, points.Count)].position);

        //timer += Time.deltaTime;
        //if (timer > 10)
           // animator.SetBool("isPatrolling", false);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange)
            animator.SetBool("IsRunning", true);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.SetDestination(initialPosition);
        agent.SetDestination(agent.transform.position);
    }
}
 */

using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
   // float timer;
    NavMeshAgent agent;
    Transform initialTransform;
    Transform player;
    float chaseRange = 5;
    Vector3 initialPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        initialTransform = GameObject.FindGameObjectWithTag("Points").transform;
        //timer = 0;
        //agent.SetDestination(initialTransform.position);
        agent = animator.GetComponent<NavMeshAgent>();
        //initialPosition = agent.transform.position;
        //agent.SetDestination(initialPosition);
        //Debug.Log("ONE STATE ENTER 83");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(initialTransform.position);
        agent.speed = 2; 
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange && distance > 2)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true);
            animator.transform.LookAt(player);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            //animator.SetBool("IsWalking", true);
            /* if(distance > chaseRange)
            {
                animator.SetBool("IsWalking", true);
                agent.SetDestination(initialPosition); 
            } */

            // Verifică distanța la poziția inițială și setează destinația la poziția inițială
            /* float distanceToInitialPosition = Vector3.Distance(agent.transform.position, initialPosition);
            if (distanceToInitialPosition > 5f) // Poate trebuie să ajustezi valoarea de aici
            {
                agent.SetDestination(initialPosition);
            } */
        }
        float distance2 = Vector3.Distance(animator.transform.position, initialTransform.position);
       
       
        if(distance2 < 1)
        {
            animator.SetBool("IsWalking", false); 
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            //animator.SetBool("IsWalking", false); 
        // Dacă dorești ca botul să se oprească când iese din starea de patrulare
        //agent.ResetPath();
    }
}
