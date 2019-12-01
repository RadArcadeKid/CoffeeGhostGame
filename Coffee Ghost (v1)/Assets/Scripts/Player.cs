using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotation_speed = 0.15f;  //parameterized this so we can change it later 

    void Start()
    {

    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if(moveHorizontal != 0 || moveVertical != 0){ //if player is moving
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotation_speed);
        }
        else{ //otherwise they're standing still 
            transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, rotation_speed);
        }


        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    //TODO: Make it so the ghosts' arms only move when they're holding coffee
}

