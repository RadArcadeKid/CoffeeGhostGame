using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Should be placed to the object which will spawn the coffee 

public class SpawnNewCoffeeCup : MonoBehaviour
{

    bool canSpawnNewCoffee; 

    bool isWithinRange; 

    public KeyCode pickupKey; //BE SURE TO MAP THIS TO AN ACTUAL BUTTON LATER 

    Vector3 spawnCoffeePosition; //will be changed later 

    public GameObject emptyCoffeeCupPrefab;  //the actual coffee cup which will be spawned 
    private GameObject newly_spawned_coffee; 

    void Start()
    {
        canSpawnNewCoffee = true; 
        spawnCoffeePosition =  new Vector3(transform.position.x-0.3f, transform.position.y+0.75f, transform.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isWithinRange == true){ //if they're within range
            if(Input.GetKeyDown(pickupKey)){ //if they're pressing the key to pick up coffee 
                if(canSpawnNewCoffee == true){ 
                    SpawnNewCoffee(); 
                }
            }
        }
    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){ //if the player is within interactable range of the crate
            isWithinRange = true;  //then they can pickup the coffee 
            //MIGHT ALSO BE A GOOD IDEA TO HAVE THE POPUP FOR THE INTERACTION UI THING SPAWN HERE!! 
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            isWithinRange = false; 
        }
        if(other.gameObject.tag == "coffee"){ //if the coffee has finally left the object
            canSpawnNewCoffee = true; //then the player can spawn a new coffee
            newly_spawned_coffee = null;  //reset newly spawned coffee 
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "coffee"){ //if there's already a coffee here
            canSpawnNewCoffee = false;  //then we can't spawn a new one 
        }
    }

    void SpawnNewCoffee(){
        Instantiate(emptyCoffeeCupPrefab, spawnCoffeePosition, Quaternion.identity);    //create the coffee spill here 
    }
}
