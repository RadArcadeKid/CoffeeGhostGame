using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeStatus : MonoBehaviour
{   
    private string coffee_status; 
    //Coffee can either be: 
        //"empty" - (plate, cup)
        //"black" - (plate, cup, just coffee)
        //"milk" - (plate, cup, coffee with milk)
        //"foam" - (plate, cup, coffee with foam)

    private Material dynamic_coffee_mat; 
    private Material empty_coffee_mat; 
    private Material black_coffee_mat; 
    private Material milk_coffee_mat; 
    private Material foam_coffee_mat; 

    Renderer cof_renderer; 

    void Start()
    {
        empty_coffee_mat = GameObject.Find("coffee_sphere_empty").GetComponent<Renderer>().material;
        black_coffee_mat = GameObject.Find("coffee_sphere_black").GetComponent<Renderer>().material; 
        milk_coffee_mat = GameObject.Find("coffee_sphere_milk").GetComponent<Renderer>().material; 
        foam_coffee_mat = GameObject.Find("coffee_sphere_foam").GetComponent<Renderer>().material; 

        SetEmpty(); //coffee should always be started at empty, then changed 
    }

    public void SetEmpty(){
        this.transform.GetChild(2).GetComponent<Renderer>().material = empty_coffee_mat; 
        coffee_status = "empty";    //no coffee yet!
    }

    public void SetBlack(){
        this.transform.GetChild(2).GetComponent<Renderer>().material = black_coffee_mat; 
        coffee_status = "black";   //DEATH METAL COFFEE!!!!!!!
    }

    public void SetWithMilk(){
        this.transform.GetChild(2).GetComponent<Renderer>().material = milk_coffee_mat; 
        coffee_status = "milk";    //for those who want to enjoy their coffee with some sweetness 
    }

    public void SetWithFoam(){
        this.transform.GetChild(2).GetComponent<Renderer>().material = foam_coffee_mat; 
        coffee_status = "foam";   //for those who want cool flowers n yummy foam in their drink 
    }


    public string GetStatus(){ 
        return coffee_status; //returns coffee_status as a string, used to be compared later!
    }
}
