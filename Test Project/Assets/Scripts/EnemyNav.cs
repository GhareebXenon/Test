using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
