using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit hit;
            bool result = Physics.Raycast(transform.position, transform.forward, out hit, 5);
            
            if (result)
            {
                Health health = hit.collider.GetComponent<Health>(); //GetComponent is asking if you have a Health component in an object.
                if(health != null) //Checking if it exists
                {
                    health.TakeDamage(50);
                }
            }
        }
    }
}
