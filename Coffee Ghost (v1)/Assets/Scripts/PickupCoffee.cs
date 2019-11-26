using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoffee : MonoBehaviour
{
    public Transform dest; //destination for where the coffee will go once picked up (can be changed depending on ghost?) 
    private bool isHolding = false; //global variable for determining if the player is holding the coffee 

    private bool isTouching = false; //should be used to determine whether the coffee is touching any other object 

    private bool isValidsurface = false;  //should be used to determine whether the object is on a valid surface or not (e.g. on a counter or not)

    public AudioSource cup_spill_src;  
    private AudioSource sound_clink_src;

    public GameObject spill_prefab;
          
    private GameObject plate_chld;   
    private GameObject cup_chld;

    Collider this_collider;

    void Start(){
        plate_chld = this.transform.GetChild(0).gameObject; //get children of CoffeeObject (plate and cup)
        cup_chld = this.transform.GetChild(1).gameObject; 
        sound_clink_src = GetComponent<AudioSource>();
        this_collider = GetComponent<Collider>(); 
    }

    void Update()
    {
        //TODO: update this so the player can only grab if the coffee is within range 
        if( Input.GetKeyDown(KeyCode.E)){
            if(isHolding == false){ //if ghost isn't already holding the coffee...
                pickup(); 
                Debug.Log("picked up coffee"); 
            }
            else{ //if the ghost IS holding the coffee
                drop();
            }
        }

    }

    private void OnTriggerEnter(Collider other) //once the cup touches a wall/table/etc, drop it!
    {
        if(isValidsurface == false){
            drop(); 
        }
    }

    void pickup(){

        sound_clink_src.Play(); 
        GetComponent<Rigidbody>().useGravity = false; //turn off the gravity so the coffee won't fall 
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; 


        this.transform.position = dest.position;  
        this.transform.parent = GameObject.Find("holdObject").transform; //transform to holdObject
        isHolding = true;     
    }

    void drop(){
        isHolding = false; //the player is no longer holding the thing 

        this.transform.parent = null; //DE-parent the object 
        GetComponent<Rigidbody>().useGravity = true; //turn gravity back on so that coffeeObj falls
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        if(isValidsurface == false){  
                this_collider.enabled = !this_collider.enabled; //disable the collider so it won't call the drop method again   
                cup_spill_src.Play();  

                //de-parent the children from the cup 
                plate_chld.transform.parent = null; 
                cup_chld.transform.parent = null; 

                StartCoroutine(SpillCoroutine(cup_chld)); 

                //create rigidbodies for the cup and plate so they fall 
                plate_chld.AddComponent<Rigidbody>();
                cup_chld.AddComponent<Rigidbody>();

        }

    } 


    IEnumerator SpillCoroutine(GameObject cup_chld)
    {
        yield return new WaitForSeconds(0.60f); //wait for a certain amount of seconds

        float x_spill = cup_chld.transform.position.x; //get the position of the cup 
        float z_spill = cup_chld.transform.position.z; 
        float y_spill = cup_chld.transform.position.y - 0.2f; 

       Vector3 spillPosition = new Vector3(x_spill, y_spill, z_spill); //change to a vector to determine exactly where to spawn the spill 

        //Vector3 spillPosition = cup_chld.transform.position;  
        Instantiate(spill_prefab, spillPosition, Quaternion.identity);    //create the coffee spill here 

        Destroy(this); //destroy the outer parent object 

    }

}
