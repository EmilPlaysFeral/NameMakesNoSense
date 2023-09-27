using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float currentHealth = 100f;
    private int currentRespawnPoint = 1;

    [SerializeField] private Image hpImage1;
    [SerializeField] private Image hpImage2;
    [SerializeField] private Image hpImage3;
    [SerializeField] private Image hpImage4;

    //[SerializeField] public Transform respawnPoint;
    [SerializeField] public Transform[] respawnPoints; //Array to hold all of my respawnPoints 

    [SerializeField] public GameObject player;
    [SerializeField] private CharacterController controller;

    [SerializeField] private AudioSource voice;
    [SerializeField] private AudioClip voiceClip;

    public void IncreaseHealth(float healthIncrease)
    {
        currentHealth += healthIncrease;
        if(currentHealth > 100)
        {
            currentHealth = 100;
        }
        //Debug.LogError(currentHealth); //skriv ut hälsan
    }

    public void SetHealth(float healthValue) //för att sätta att över 100 är nejnej
    {
        currentHealth = healthValue;
    }
    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        //Debug.LogError(currentHealth); //Kolla den som tog damage's HP alltså både spelaren och fienden

       /* if (this.CompareTag("Enemy"))
        {
            voice.PlayOneShot(voiceClip);
        }*/

        if(currentHealth <= 0) //if someone with health drops below 0 HP
        {
            if(GetComponent<EnemyPatrol>() != null)
            {
                //this means that this health component belongs to an enemy, so I can increase the death counter
                EnemyManager.GetInstance().IncreaseDeadEnemies(); //we obtain the singleton instance and have access to its functions without knowing the object itself
            }
            if (CompareTag("Player")) //Om spelaren dör
            {
                //Debug.Log("Spelaren dog");
                Respawn();
            }else
            {
                voice.PlayOneShot(voiceClip);
                Destroy(gameObject); //Om fienden dör, förstår objektet
            }
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    /*
    private void Start() //Remove when Respawn works again, currently just trying to Debug
    {
        foreach (Transform point in respawnPoints)
        {
            Debug.Log("Respawn Point Name: " + point.name);
        }
    } */

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

        if (Input.GetKeyDown(KeyCode.R) && CompareTag("Player")) //Debug Respawn
        {
            Respawn();
        }
    }
    
    /*public void PlayerDies()
    {
        Debug.Log("Player dies");
        //Sätt positionen på spelaren till en RespawnPoint // Put the position of the player at a RespawnPoint
        player.transform.position = respawnPoint.transform.position;
        currentHealth = 100;  //Sätt spelarens hälsa till 100
    } */
    public void Respawn()
    {
        if (currentRespawnPoint <= respawnPoints.Length)
        {
            player.GetComponent<CharacterController>().enabled = false;
            //player.transform.position = respawnPoint.position; //putting the player at the respawn location when it's only 1 location
            player.transform.position = respawnPoints[currentRespawnPoint - 1].position;
            //Debug.Log("Respawned at " + respawnPoints[currentRespawnPoint - 1].name);
            player.GetComponent<CharacterController>().enabled = true;
            currentHealth = 100;
            //currentRespawnPoint++; //Nu alternerar jag via varje respawnPoint
        }
        else
        {
            //Debug.LogWarning("No more respawn points available.");
        }
    }

    private void OnTriggerEnter(Collider other) //Doesn't currently work
    {
        if (other.CompareTag("RespawnTrigger"))
        {
            //Debug.Log("Successful first collision with an Object called RespawnTrigger");
            //Debug.Log("Collided with object tagged as: " + other.tag); 

            int newRespawnIndex = System.Array.IndexOf(respawnPoints, other.transform);

            // Log the size of the respawnPoints array for debugging
            //Debug.Log("RespawnPoints Array Size: " + respawnPoints.Length);

            if (newRespawnIndex >= 0)
            {
                // Update the current respawn point
                currentRespawnPoint = newRespawnIndex + 1;
                //Debug.Log("Player will respawn at " + other.transform.name);

                // For further debugging, log the current respawn point
                //Debug.Log("Current Respawn Point: " + currentRespawnPoint);
            }
            else
            {
                // Log when the trigger collider was not found in the respawnPoints array
                //Debug.LogWarning("Trigger collider not found in respawnPoints array.");
            }
        }
    }
}
