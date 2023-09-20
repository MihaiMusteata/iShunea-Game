/* using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
   // float timer;
    NavMeshAgent agent;
    Transform initialTransform;
    Transform player;
    float chaseRange = 5;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //IdleBehaviour InitialPoz;
       
        //newTransform.position = InitialPoz.initialPosition;
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


 */