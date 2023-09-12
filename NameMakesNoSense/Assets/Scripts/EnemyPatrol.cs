using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private Transform position1; //patrol pos1
    [SerializeField] private Transform position2; //patrol pos2

    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent.SetDestination(position1.position); //use navmesh agent to walk to this destination
        currentTarget = position1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAgent.remainingDistance < 0.35f)
        {
            if (currentTarget == position1.position)
            {
                currentTarget = position2.position;
            }
            else
            {
                currentTarget = position1.position;
            }
            enemyAgent.SetDestination(currentTarget);
        }
    }
}
