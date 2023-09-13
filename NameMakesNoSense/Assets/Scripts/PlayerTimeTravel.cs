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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            float currentHealth = GetComponent<Health>().GetCurrentHealth();
            PlayerState playerState = new PlayerState(transform.position, transform.eulerAngles, currentHealth);
            saveStates.Add(playerState);
        }

        if (Input.GetKeyDown(KeyCode.E) && saveStates.Count > 0)
        {
            PlayerState playerState = saveStates[saveStates.Count - 1];
            transform.position = playerState.GetPosition();
            transform.eulerAngles = playerState.GetRotation();
        }
    }
}
