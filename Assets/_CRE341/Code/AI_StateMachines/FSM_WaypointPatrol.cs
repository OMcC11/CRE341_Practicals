using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using System.Collections.Generic;

public class FSM_WaypointPatrol : StateMachineBehaviour
{
    GameObject NPC_New;

    private float timer = 0.0f;
    public float lengthOfTimeToChaseWaypoint = 10.0f;

    // list of gameObject waypoints
    List<GameObject> waypoints;
    [SerializeField] Transform WaypointTarget;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // debug statement 
        Debug.Log("Entering Patrol State");

        // get all waypoints with tag Waypoint
        waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
        WaypointTarget = waypoints[Random.Range(0, waypoints.Count)].transform;

        NPC_New = animator.transform.parent.gameObject;
        NPC_New.GetComponent<NavMeshAgent>().SetDestination(WaypointTarget.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug log showing the current state
        Debug.Log("On State Update ~ Patrol State");

        if (timer < lengthOfTimeToChaseWaypoint)
        {
            timer += 1.0f * Time.deltaTime;
        }
        else if (timer >= lengthOfTimeToChaseWaypoint)
        {
            timer = 0.0f;
            WaypointTarget = waypoints[Random.Range(0, waypoints.Count)].transform;
            NPC_New.GetComponent<NavMeshAgent>().SetDestination(WaypointTarget.position);
        }

        // get parent object of the object containing the animator
        //if (Vector3.Distance(NPC_00.transform.position, WaypointTarget.position) < 0.1f)
        //{
        //    WaypointTarget = waypoints[Random.Range(0, waypoints.Count)].transform;
        //    NPC_00.GetComponent<NavMeshAgent>().SetDestination(WaypointTarget.position);
        //}
        
        //NPC_00.transform.position = Vector3.MoveTowards(animator.transform.position, WaypointTarget.position, GameManager.Instance.NPC_AI_01.Speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // debug statement 
        Debug.Log("Exiting Patrol State");
    }

}
