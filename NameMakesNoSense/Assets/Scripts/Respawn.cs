using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Health health; //Testa om health.GetCurrentHealth <= 0 etc
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController characterController;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nu rör du");
    }
}
