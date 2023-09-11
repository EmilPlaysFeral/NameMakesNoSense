using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTestScript : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private Rigidbody playerBody;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.eulerAngles;

        if(Input.GetAxis("Horizontal") != 0)
        {
            Vector3 direction = Vector3.right * (Input.GetAxis("Horizontal"));
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 direction = Vector3.forward * (Input.GetAxis("Vertical")); //Vector3.up skulle göra att den flyger
            transform.Translate(direction * speed * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce);
        }
    }
}
