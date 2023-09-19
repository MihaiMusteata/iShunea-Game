using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    Transform botTransform;
    private NavMeshAgent agent;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();

        botTransform = animator.transform; 

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
        
    }
 
    
 /* private void StartCooldown()
    {
        // Așteaptă pentru perioada de cooldown
        StartCoroutine(AttackCooldownCoroutine());
    }

    // Coroutine pentru gestionarea cooldown-ului
    private IEnumerator AttackCooldownCoroutine()
    {
        // Așteaptă pentru perioada de cooldown
        yield return new WaitForSeconds(attackCooldown);

        // După ce s-a terminat cooldown-ul, poți ataca din nou
        canAttack = true;
    } */
}
 