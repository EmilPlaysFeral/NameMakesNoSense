using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private MeshRenderer meshRenderer;
    //[SerializeField] private Color aggroColor;
    [SerializeField] private EnemyQualities enemyQualities;

    void Start()
    {
        navMeshAgent.speed = enemyQualities.GetRegularSpeed();
        EnemyManager.ThresholdReached += GoAggro; //Subscribing to the event
    }

    private void OnDestroy()
    {
        EnemyManager.ThresholdReached -= GoAggro;
    }

    private void GoAggro()
    {
        //navMeshAgent.speed += 2f; //Increase speed
        navMeshAgent.speed = enemyQualities.GetAggroSpeed();
        //meshRenderer.material.color = aggroColor; //change color of enemy
        meshRenderer.material.color = enemyQualities.GetAggroColor();
        EnemyManager.ThresholdReached -= GoAggro; //Unsubscribing to the event
    }

    private void OnTriggerEnter(Collider collision) //Astrid GOAT kod LETS GOOOO!!!!!
    {
        if (collision.gameObject.tag == "Player")
        {
            Health health = collision.GetComponent<Health>();
            if (health != null) //Checking if it exists
            {
                health.TakeDamage(enemyQualities.GetDamage());
            }
        }
    }
}
