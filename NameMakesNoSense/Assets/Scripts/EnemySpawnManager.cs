using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private static EnemySpawnManager instance;
    [SerializeField] private GameObject enemyPrefab;

    public static EnemySpawnManager GetInstance()
    {
        return instance;
    }

    public void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
    }
    
}
