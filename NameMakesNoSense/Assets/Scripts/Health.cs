using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float currentHealth = 100f;

    [SerializeField] private Image hpImage1;
    [SerializeField] private Image hpImage2;
    [SerializeField] private Image hpImage3;
    [SerializeField] private Image hpImage4;

    [SerializeField] public Transform respawnPoint;
    [SerializeField] public GameObject player;

    public void IncreaseHealth(float healthIncrease)
    {
        currentHealth += healthIncrease;
        Debug.LogError(currentHealth);
    }
    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        Debug.LogError(currentHealth);

        if(currentHealth <= 0) //if someone with health drops below 0 HP
        {
            if(GetComponent<EnemyPatrol>() != null)
            {
                //this means that this health component belongs to an enemy, so I can increase the death counter
                EnemyManager.GetInstance().IncreaseDeadEnemies(); //we obtain the singleton instance and have access to its functions without knowing the object itself
            }
            if (CompareTag("Player")) //Om spelaren dör
            {
                //Visa 0 liv
                Debug.Log("Spelaren dog");
                PlayerDies();
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

    private void Update()
    {
        if (CompareTag("Player"))
        {
            if (currentHealth <= 75f)
            {
                hpImage1.gameObject.SetActive(false);
            }
            else
            {
                hpImage1.gameObject.SetActive(true);
            }

            if (currentHealth <= 50f)
            {
                hpImage2.gameObject.SetActive(false);
            }
            else
            {
                hpImage2.gameObject.SetActive(true);
            }

            if (currentHealth <= 25f)
            {
                hpImage3.gameObject.SetActive(false);
            }
            else
            {
                hpImage3.gameObject.SetActive(true);
            }
            if (currentHealth <= 0f)
            {
                hpImage4.gameObject.SetActive(false);
            }
            else
            {
                hpImage4.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.M) && CompareTag("Player"))
        {
            Respawn();
        }
    }
    
    public void PlayerDies()
    {
        Debug.Log("Player dies");
        //Sätt positionen på spelaren till en RespawnPoint // Put the position of the player at a RespawnPoint
        player.transform.position = respawnPoint.transform.position;
        currentHealth = 100;  //Sätt spelarens hälsa till 100
    }
    public void Respawn()
    {
        player.transform.position = respawnPoint.position; //trying to spam put the player at the Respawn position
        Debug.Log(respawnPoint.name);
    }   
}
