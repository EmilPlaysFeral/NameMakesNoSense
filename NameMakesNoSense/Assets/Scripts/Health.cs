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
            Destroy(gameObject);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
