using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)); //Random position

            Instantiate(healthPrefab, randomPosition, Quaternion.identity); //What are you creating, where are you putting it, and what rotation
        }
    }
}
