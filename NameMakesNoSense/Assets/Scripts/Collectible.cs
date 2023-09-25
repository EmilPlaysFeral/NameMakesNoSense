using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>(); //The other collider that produced the triggering. The thing that collided with me
        if(health != null) //Whoever entered triggerfield have a health component or not check.
        {
            health.IncreaseHealth(25);
            /*if(health.GetCurrentHealth() > 100)
            {
                health.SetHealth(100);
            }*/
            Destroy(gameObject);
        }
    }
}
