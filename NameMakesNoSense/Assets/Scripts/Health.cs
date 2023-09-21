using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth = 100f;

    //[SerializeField] public Transform respawnPoint;
    //[SerializeField] public GameObject player;

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
            if (CompareTag("Player")) //Om spelaren dör
            {
                Debug.Log("Spelaren dog");
                //PlayerDies();
            }else
            {
                Destroy(gameObject); //Om fienden dör, förstår objektet
            }
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    /*
    public void PlayerDies()
    {
        //Debug.Log("Spelaren dör");
        //Sätt positionen på spelaren till en RespawnPoint
        //player.transform.position = respawnPoint.transform.position;
        //currentHealth = 100;  //Sätt spelarens hälsa till 100
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && CompareTag("Player"))
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        player.transform.position = respawnPoint.position;
        Debug.Log("Hejhopp du ska flyttas");
    }
    */
}
