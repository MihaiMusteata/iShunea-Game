/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Transform initialTransform;
    float attackRange = 3;
    float chaseRange = 5;
    //Vector3 initialPosition;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1;
        //initialPosition = agent.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialTransform = GameObject.FindGameObjectWithTag("Points").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);
        
        agent.SetDestination(player.position);
        animator.transform.LookAt(player.position);
       // Debug.Log("distance = "+ distance);
        if (distance <= attackRange)
        {
            animator.SetBool("IsAttacking01", true);
            //animator.SetBool("IsRunning", false);
        }

        
        float distance2 = Vector3.Distance(animator.transform.position, initialTransform.position);
        if (distance < 2)
        {

            animator.SetBool("IsRunning", false);
            //animator.SetBool("IsWalking", true);
            //agent.SetDestination(initialPosition);
           
        }
        if(distance > chaseRange)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", true);
            
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

        //agent.SetDestination(initialTransform.position);
        //agent.speed = 2; 
    }
}
 */