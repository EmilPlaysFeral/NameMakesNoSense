using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour //Egenkodat script!
{
    [SerializeField] public GameObject player; 

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Första TriggerEnter sker");
        if (other.CompareTag("Player")) //if the collider that entered is of the tag Player
        {
            //Debug.Log("Andra sker, taggen är player");
            player.GetComponent<Health>().Respawn(); 
        }
    }

}
