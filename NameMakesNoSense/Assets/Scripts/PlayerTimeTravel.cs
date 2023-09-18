using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeTravel : MonoBehaviour
{
    private List<PlayerState> saveStates;

    // Start is called before the first frame update
    void Start()
    {
        saveStates = new List<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //I create a new timestamp everytime I press Q
        {
            float currentHealth = GetComponent<Health>().GetCurrentHealth(); //Here I obtain the health
            PlayerState playerState = new PlayerState(transform.position, transform.eulerAngles, currentHealth); //Here I create a PlayerState with the players position, rotation?, and current health
            saveStates.Add(playerState); //Here I save that playerState to a List
        }

        if (Input.GetKeyDown(KeyCode.E) && saveStates.Count > 0) //Loads the last saved state that I created in the list
        {
            PlayerState playerState = saveStates[saveStates.Count - 1]; //Whichever is last saved I pick
            transform.position = playerState.GetPosition(); //Obtain the position
            transform.eulerAngles = playerState.GetRotation(); //Obtain the rotation
        }
    }
}
