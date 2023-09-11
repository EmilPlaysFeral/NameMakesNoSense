using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour //means it will be attachable to an object
{
    // Start is called before the first frame update
    void Start() //Executed everytime you hit play, once.
    {
        transform.position = new Vector3(18,0,0); //Object Moves X way when starting the game
    }

    // Update is called once per frame
    void Update() //Executed everytime a frame is updated
    {
        //transform.position =+ new Vector3(0.003f,0,0);
    }
}
