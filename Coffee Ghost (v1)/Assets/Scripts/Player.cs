using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotation_speed = 0.15f;  //parameterized this so we can change it later 
    public int joystickNum;
    float moveHorizontal, moveVertical;

    void Start()
    {

    }

    void Update()
    {
        string joystickString = joystickNum.ToString();
        if (Input.GetJoystickNames().Length > 0)
        {
            moveHorizontal = Input.GetAxis("LeftJoystickX_P" + joystickString);
            moveVertical = Input.GetAxis("LeftJoystickY_P" + joystickString);

        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal_P" + joystickString);
            moveVertical = Input.GetAxis("Vertical_P" + joystickString);
            //Debug.Log("No Controller, Switching Inputs");
        }
        //Debug.Log("Num joysticks: " + Input.GetJoystickNames().Length);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if(moveHorizontal != 0 || moveVertical != 0){ //if player is moving
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotation_speed);
        }
        else{ //otherwise they're standing still 
            transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, rotation_speed);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        //player boundary
        Vector3 clampedPosition = transform.position;
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -11.5f, 4.75f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -10.0f, 14.35f);
        transform.position = clampedPosition;
    }

    //TODO: Make it so the ghosts' arms only move when they're holding coffee
}

