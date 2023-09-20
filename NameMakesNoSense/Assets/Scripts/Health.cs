using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth = 100f;

    // Start is called before the first frame update
    
    public void IncreaseHealth(float healthIncrease)
    {
        currentHealth += healthIncrease;
        Debug.LogError(currentHealth);
    }
    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        Debug.LogError(currentHealth);
        if(currentHealth <= 0)
        {
            if(GetComponent<EnemyPatrol>() != null)
            {
                //this means that this health component belongs to an enemy, so I can increase the death counter
                EnemyManager.GetInstance().IncreaseDeadEnemies(); //we obtain the singleton instance and have access to its functions without knowing the object itself
            }
            Destroy(gameObject);
        }

        if (currentHealth <= 0)
        {
            if (GetComponent<PlayerMovementTestScript>() != null)
            {
                //this means that this health component belongs to the player
                EnemyManager.GetInstance().IncreaseDeadEnemies(); //we obtain the singleton instance and have access to its functions without knowing the object itself
            }
            Destroy(gameObject);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
