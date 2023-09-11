using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTestScript : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            Vector3 direction = transform.right * (Input.GetAxis("Horizontal"));
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 direction = transform.forward * (Input.GetAxis("Vertical")); //Vector3.up skulle göra att den flyger
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
