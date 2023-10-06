using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyArena : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform hockeyArena;
    private bool hasPlayerEntered = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayerEntered = true;

        }
    }

    private void Update()
    {
        if (hasPlayerEntered && Input.GetKeyDown(KeyCode.B))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = hockeyArena.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayerEntered = false;

        }
    }

}
