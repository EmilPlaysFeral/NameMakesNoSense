using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color aggroColor;

    void Start()
    {
        EnemyManager.ThresholdReached += GoAggro; //Subscribing to the event
    }

    private void GoAggro()
    {
        navMeshAgent.speed += 2f; //Increase speed
        meshRenderer.material.color = aggroColor; //change color of enemy
        EnemyManager.ThresholdReached -= GoAggro; //Unsubscribing to the event
    }
}
