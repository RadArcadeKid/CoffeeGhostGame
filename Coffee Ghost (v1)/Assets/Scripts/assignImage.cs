using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assignImage : MonoBehaviour
{
     private AssignCoffee otherscript;
     public Sprite foam;
     public Sprite black;
     public Sprite milk;

     // Start is called before the first frame update
     void Start()
     {

     }
 
     // Update is called once per frame
     void Update()
     {
         if (otherscript.cust1 == "foam")
         {
             SetFoam();
             
         }
         if (otherscript.cust1 == "black")
         {
             Debug.Log("black");
             SetBlack();
             
         }
         if (otherscript.cust1 == "milk")
         {
             Debug.Log("milk");
             SetMilk();
         }
 
     }
 
     public void SetFoam()
     {
         Debug.Log("foamed");
         gameObject.GetComponent<SpriteRenderer>().sprite = foam;
     }
 
     public void SetMilk()
     {
          gameObject.GetComponent<SpriteRenderer>().sprite = milk;
     }
     public void SetBlack()
     {
         gameObject.GetComponent<SpriteRenderer>().sprite = black;
     }
 }
