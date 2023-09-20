using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour //Singleton
{
    private static EnemyManager instance; //Singleton
    private int totalEnemies;
    private int deadEnemies;
    [SerializeField] private float aggroThreshold = 0.5f;   

    public delegate void EnemyEvents(); 
    public static EnemyEvents ThresholdReached; //First event created
    private bool thresholdHasReached = false;

    public static EnemyEvents PlayerWonGame;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        // By doing this we can find find all the enemies in the scene, which allows me to have the total amount
        EnemyPatrol[] allEnemies = GameObject.FindObjectsByType<EnemyPatrol>(FindObjectsSortMode.None);
        totalEnemies = allEnemies.Length;
    }


    public static EnemyManager GetInstance()
    {
        return instance;
    }

    public void IncreaseDeadEnemies()
    {
        deadEnemies++;
        if(deadEnemies / totalEnemies > aggroThreshold && !thresholdHasReached)
        {
            thresholdHasReached = true;
            ThresholdReached();
        }

        if(deadEnemies == totalEnemies)
        {
            PlayerWonGame();
        }
    }

    public int GetDeadEnemies()
    {
        return deadEnemies;
    }

    public int GetTotalEnemies()
    {
        return totalEnemies;
    }  
}
