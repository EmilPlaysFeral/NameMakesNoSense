using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingMine : MonoBehaviour
{
    [SerializeField] private AudioSource voice;
    [SerializeField] private AudioClip voiceClip;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>(); //The other collider that produced the triggering. The thing that collided with me
        if (health != null) //Whoever entered triggerfield have a health component or not check.
        {
            if (other.gameObject.tag == "Player")
            {
                health.TakeDamage(50);
                voice.PlayOneShot(voiceClip);
            }
            Destroy(gameObject);
        }
    }
}
