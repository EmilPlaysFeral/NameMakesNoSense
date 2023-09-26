using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] public NavMeshAgent enemy;
    [SerializeField] public Transform player;


    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(this.transform.position, player.position, 10 * Time.deltaTime);
        enemy.SetDestination(player.position);
    }
}
