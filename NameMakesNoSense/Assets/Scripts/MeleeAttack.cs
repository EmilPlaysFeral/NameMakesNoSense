using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius;

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MultiAttack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            SingleAttack();
        }
    }

    private void SingleAttack()
    {
            RaycastHit hit;
            bool result = Physics.Raycast(transform.position, transform.forward, out hit, 5);

            if (result)
            {
                Health health = hit.collider.GetComponent<Health>(); //GetComponent is asking if you have a Health component in an object.
                if (health != null) //Checking if it exists
                {
                    health.TakeDamage(50);
                }
            }
    }

    private void MultiAttack() //Funkar inte, detta är självmord just nu
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Health>() != null)
            {
                Health health = hitCollider.GetComponent<Health>();
                health.TakeDamage(10);
            }
        }
    }

}
