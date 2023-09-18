using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehaviour : StateMachineBehaviour
{
    /* public IdleBehaviour(){} */
    float timer;
    Transform player;
    Transform initialTransform;
   // NavMeshAgent agent;
    NavMeshAgent agent;
    float chaseRange = 5;
    public Vector3 initialPosition;
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent = animator.GetComponent<NavMeshAgent>();
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //initialTransform = GameObject.FindGameObjectWithTag("Points").transform;
        initialPosition = agent.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        //if (timer > 5)
           // animator.SetBool("isPatrolling", true);

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < chaseRange && distance > 2)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
            animator.transform.LookAt(player);
        }
      /*   else if(distance > chaseRange)
        {
            animator.SetBool("IsWalking", true);
            //agent.SetDestination(initialPosition); 
        } */
         /* float distance2 = Vector3.Distance(animator.transform.position, initialTransform.position);
        if(distance2 != 0 && distance > 6)
        {
            animator.SetBool("IsWalking", true);
            agent.SetDestination(initialTransform.position);
            agent.speed = 2; 
        }
        else if(distance2 < 1 && distance > 6)
            animator.SetBool("IsWalking", false);  */

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  /*    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        initialPosition = agent.transform.position;
    }  */
}
