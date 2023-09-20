/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehaviour : StateMachineBehaviour
{
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
      

    }
}
 */