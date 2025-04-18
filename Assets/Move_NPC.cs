//Old Code
//using UnityEngine;
//using UnityEngine.AI;

//public class Move_NPC : MonoBehaviour
//{
//    GameObject player;
//    NavMeshAgent agent;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        player = GameObject.Find("Player");
//        agent = GetComponent<NavMeshAgent>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Move the NPC to the player
//        agent.SetDestination(player.transform.position);

//    }
//}


//New Improved Code
using UnityEngine;
using UnityEngine.AI;

public class Move_NPC : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] private float circleRadius = 5f; // Adjustable radius visible in inspector
    [SerializeField] private float hysteresis = 1f; // Extra buffer distance to prevent rapid toggling

    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

        // Start updating destination every second (first update after 0.1 seconds)

        InvokeRepeating("UpdateDestination", 0.1f, 1.0f);
    }

    void Update()
    {
        // Empty - no longer needed for destination updates
    }

    void UpdateDestination()
    {
        // Check if player is within (stopping distance + hysteresis)
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= agent.stoppingDistance + hysteresis)
        {
            // Player is close enough, don't update destination
            return;
        }

        // Generate random angle in radians

        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate position on circle circumference

        Vector3 targetPos = player.transform.position;

        targetPos.x += Mathf.Cos(randomAngle) * circleRadius;

        targetPos.z += Mathf.Sin(randomAngle) * circleRadius;

        // Move the NPC to the random position on circle around player so they all don't go to the same location
        agent.SetDestination(targetPos);
    }
}
