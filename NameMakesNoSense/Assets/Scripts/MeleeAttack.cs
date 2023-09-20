using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    [SerializeField] private GameObject singRay; //weapon1
    [SerializeField] private GameObject singRay2; //weapon2
    [SerializeField] private AudioSource voice;
    [SerializeField] private AudioClip voiceClip;

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MultiAttack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            SingleAttack();
            if (!singRay.activeInHierarchy)
            {
                StartCoroutine(ShowRay());
                //voice.PlayOneShot(voiceClip); //Trigger the soundeffect once while showing the ray
            }
            //voice.Play(); //For ambience in new areas for example
            //voice.Pause(); //For ambience
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

    private IEnumerator ShowRay()
    {
        if (!singRay.activeInHierarchy)
        {
        singRay.SetActive(true);
        singRay2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        singRay.SetActive(false);
        singRay2.SetActive(false);
        }
    }

}
