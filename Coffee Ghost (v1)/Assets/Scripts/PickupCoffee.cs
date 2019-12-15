using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoffee : MonoBehaviour
{
    //public Transform dest; //destination for where the coffee will go once picked up (can be changed depending on ghost?) 
    //private Vector3 dest; 
    private Transform dest; 

    private bool isHolding = false; //global variable for determining if the player is holding the coffee 

    private bool isValidsurface = false;  //should be used to determine whether the object is on a valid surface or not (e.g. on a counter or not)

    private bool isWithinRange = false; 

    public AudioSource cup_spill_src;  
    private AudioSource sound_clink_src;

    public GameObject spill_prefab;
          
    private GameObject plate_chld;   
    private GameObject cup_chld;
    private GameObject coffee_chld; 

    private GameObject this_player; 

    public KeyCode pickupKey;
    public int joystickNum;

    Collider this_collider;

    void Start(){
        plate_chld = this.transform.GetChild(0).gameObject; //get children of CoffeeObject (plate and cup)
        cup_chld = this.transform.GetChild(1).gameObject; 
        coffee_chld = this.transform.GetChild(2).gameObject; 
        sound_clink_src = GetComponent<AudioSource>();
        this_collider = GetComponent<Collider>(); 
    }

    void Update()
    {
        string joystickString = joystickNum.ToString();
        if (Input.GetKeyDown(pickupKey) || Input.GetButtonDown("X_P" + joystickString)){
            if(isHolding == false){ //if ghost isn't already holding the coffee...
                if(isWithinRange == true){ //if the ghost is within range 
                        pickup(); 
                }
            }
            else{ //if the ghost IS holding the coffee
                drop();
            }
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player"){ //if player is close to coffee
            isWithinRange = true;
            this_player = other.gameObject; //set the player equal to the gameobject (player) that just collided 
            if(other.gameObject.name == "Blue"){
                joystickNum = 1;
                pickupKey = KeyCode.RightShift;
                dest = this_player.transform.Find("holdObject"); //set the destination to the player's holdobj
            }
            if(other.gameObject.name == "misty"){
                joystickNum = 2;
                pickupKey = KeyCode.E;
                dest = this_player.transform.Find("holdObject_m"); 
            }

            //Debug.Log(this_player.name);
        }
        if(other.gameObject.tag == "table" || other.gameObject.tag == "counter" || other.gameObject.tag == "machine"){
            isValidsurface = true; 
            //Debug.Log("isValisurface = true");
        }
        else{
            if(isValidsurface == false){
                drop(); //once the cup touches a wall/table/etc, drop it!
            }
        }
    }

    private void OnTriggerExit(Collider other){

        if(other.gameObject.tag == "Player"){
            isWithinRange = false;
            this_player = null;  //reset the player object to null so that the next player can pick it up 
        }
        if(other.gameObject.tag == "table" || other.gameObject.tag == "counter" || other.gameObject.tag == "machine"){
            isValidsurface = false; 
            //Debug.Log("no longer on valid surface");
        }

        if(isHolding == false){
            dest = null; //reset destination after leaving AND when they're not holding it, so that the coffee's destination can be set elsewhere 
        }
    }

    void pickup(){

        MoveHands hand_script = this_player.GetComponent(typeof(MoveHands)) as MoveHands; //get the script for the current player grabbing 
        hand_script.SetPickupHands(); //set the pickup hands so the player is picking the thing up  

        sound_clink_src.Play(); 
        this.GetComponent<Rigidbody>().useGravity = false; //turn off the gravity so the coffee won't fall 
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; 
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition; 

        this.transform.position = dest.position;  //update dest position!!! 
        //this.transform.position = dest;  //update the position!!! 

        this.transform.parent = dest.transform; //transform to holdObject
        isHolding = true;     
    }

    void drop(){
        MoveHands hand_script = this_player.GetComponent(typeof(MoveHands)) as MoveHands; //get the script for the current player grabbing 
        hand_script.SetDefaultHands(); 

        isHolding = false; //the player is no longer holding the thing 

        this.transform.parent = null; //DE-parent the object 
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<Rigidbody>().useGravity = true; //turn gravity back on so that coffeeObj falls normally 

        if(isValidsurface == false){   //dropping/colliding with non-valid object (spilling and dropping the coffee)

                this_collider.enabled = !this_collider.enabled; //disable the collider so it won't call the drop method again   
                cup_spill_src.Play();  //play the sound of a spill 

                //de-parent the children from the cup 
                plate_chld.transform.parent = null; 
                cup_chld.transform.parent = null; 

                StartCoroutine(SpillCoroutine(cup_chld)); 

                //create rigidbodies for the cup and plate so they fall 
                plate_chld.AddComponent<Rigidbody>();
                cup_chld.AddComponent<Rigidbody>();

        }
        else{ //droping on a valid object (won't spill the coffee)
            sound_clink_src.Play(); 
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX; 
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ; 
        }
    } 


    IEnumerator SpillCoroutine(GameObject cup_chld)
    {
        yield return new WaitForSeconds(0.53f); //wait for a certain amount of seconds

        CoffeeStatus coffee_status_script = this.GetComponent(typeof(CoffeeStatus)) as CoffeeStatus; //get the coffee status script 
        if(coffee_status_script.GetStatus() != "empty"){ //if the coffee cup isn't empty...

            float x_spill = cup_chld.transform.position.x; //get the position of the cup 
            float z_spill = cup_chld.transform.position.z; 
            float y_spill = cup_chld.transform.position.y - 0.2f; 
            Vector3 spillPosition = new Vector3(x_spill, y_spill, z_spill); //change to a vector to determine exactly where to spawn the spill 

            //Vector3 spillPosition = cup_chld.transform.position;  

            Instantiate(spill_prefab, spillPosition, Quaternion.identity);    //create the coffee spill here 
        }


        //regardless of its empty status or not, we destroy the coffee object inside, and then the collider around it
        Destroy(coffee_chld);
        Destroy(this.gameObject); 
    }
}
