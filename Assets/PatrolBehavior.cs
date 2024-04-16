using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : StateMachineBehaviour
{
    float timer;
    List<Vector3> waypoints = new List<Vector3>();
    NavMeshAgent agent;
    Transform player;
    float ChaseRange = 10;
    float waypointRadius = 10f;
    
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0; 
    
        waypoints.Clear();
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            Vector3 randomPosition = randomDirection * Random.Range(0, waypointRadius);
            Vector3 waypoint = animator.transform.position + randomPosition;
    
            waypoints.Add(waypoint);
        }
    
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0]);
    
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
     
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)]);
        }
    
        timer += Time.deltaTime;
        if(timer > 10)
        {
            animator.SetBool("isPatrolling", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
