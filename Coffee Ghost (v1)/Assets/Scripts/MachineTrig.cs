﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTrig : MonoBehaviour
{
    private Durability durab_script;
    private Cooking cook_script;

    private CoffeeStatus coffee_script; 
    // private floatingUIController fl_UIcontr;
    // private floatingUI fl_UI;

    public GameObject FloatingTextPrefab;

    public GameObject this_coffee; 

    // public GameObject UIBarParent;
    public KeyCode cookKey;
    public KeyCode repairKey;
    

    Collider this_collider;

    
    bool Blue_active = false;
    bool misty_active = false;
    bool coffee_Active = false;
    bool operable = true;
    // Start is called before the first frame update
    void Start()
    {
        this_collider = GetComponent<Collider>();
        durab_script = GetComponent<Durability>();
        cook_script = GetComponent<Cooking>();
        
        // floatingUIController.CreateFloatingUI(transform);
        //this_collider.enabled; 
        Debug.Log("Set up collider");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Blue is in position
        if(Blue_active != false && durab_script.DurabilityCheck() == false)
        {
            // Trigger Floating text here
            if(FloatingTextPrefab != null)
            {
                ShowFloatingText();
            }
            // Fix Machine
            durab_script.Fix(repairKey);

        }
        else if(durab_script.operable == true)
        {
            Debug.Log("Can't fix, machine is operable");
        }
        // Check if misty is in position
        if(misty_active != false && durab_script.operable && coffee_Active != false)
        {
            // Trigger Floating text
            if(FloatingTextPrefab != null)
            {
                ShowFloatingText();
            }
            // Spawn Coffee
            // fl_UI.SetDurabSlider(cookKey);
            cook_script.Cook(cookKey);
        }
        else if(durab_script.operable == false)
        {
            Debug.Log("Can't cook, machine is inoperable");
        }

    }


    void ShowFloatingText()
    {
        if(FloatingTextPrefab == null)
        {
            var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            go.GetComponent<TextMesh>().text = cookKey.ToString();
        }
        // var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        // go.GetComponent<TextMesh>().text = cookKey.ToString();
    }

    // void ShowFloatingUI()
    // {
    //     if(UIBarParent != null)
    //     {
    //         var go2 = Instantiate(UIBarParent, transform.position, Quaternion.identity, transform);
    //         go2.GetComponent<TextMesh>().text = cookKey.ToString();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("HELLO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            if(other.gameObject.name == "Blue")
            {
                Blue_active = true;
                Debug.Log(other.gameObject.name + " has entered!!!");
            }
            if(other.gameObject.name == "misty")
            {
                misty_active = true;
                Debug.Log(other.gameObject.name + " has entered!!!");
            }

        }
        if(other.gameObject.tag == "coffee")
        {
            this_coffee = other.gameObject; //set the player equal to the gameobject (player) that just collided 
            coffee_script = other.GetComponent<CoffeeStatus>(); //update the coffeescript

            coffee_script.SetBlack();
            Debug.Log("Coffee entered, parenting game object and setting coffee to black"); 

            coffee_Active = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Blue")
        {
            Blue_active = false;
        }
        if(other.gameObject.name == "misty")
        {
            misty_active = false;
        }
        Debug.Log(other.gameObject.name + " has left!!!");

        if(other.gameObject.tag == "coffee")
        {
            this_coffee = null;
            coffee_Active = false;
            coffee_script = null; 

             Debug.Log("coffee is now no longer in the trigger"); 

        }
    }
    public void PullTrigger(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("HELLO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            if(other.gameObject.name == "Blue")
            {
                Blue_active = true;
                Debug.Log(other.gameObject.name + " has entered!!!");
            }
            if(other.gameObject.name == "misty")
            {
                misty_active = true;
                Debug.Log(other.gameObject.name + " has entered!!!");
            }

        }
        if(other.gameObject.tag == "coffee")
        {
            coffee_Active = true;
        }
    }

}
