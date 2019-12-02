using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHands : MonoBehaviour
{
    public GameObject leftHand; 
    public GameObject rightHand; 

    Vector3 rh_end_position;
    Vector3 lh_end_position;

    bool movehands = false; 

    float time_move = 0.15f; 
    
    void Start(){

        SetDefaultHands(); 
    }

    public void SetDefaultHands(){ //transform position to the default posution of where the hands go normally
        rightHand.transform.localPosition = new Vector3(0.515f, 0.154f, -0.179f);
        leftHand.transform.localPosition = new Vector3(-0.515f, 0.154f, -0.179f);
    }

    public void SetPickupHands(){ //transform position to the default posution of where the hands go when holding
        rightHand.transform.localPosition = new Vector3(0.164f, 0.48f, 0.34f);
        leftHand.transform.localPosition = new Vector3(-0.143f, 0.48f, 0.34f);
    }

    //NOTE - i kept trying to get this animation to play smoothly - I spent like 2 hours trying to get this. 
    //Turns out, Vector3.Lerp doesn't actually work with a localPosition, which is how this object moves...so, can't make it smooth for now 
}
