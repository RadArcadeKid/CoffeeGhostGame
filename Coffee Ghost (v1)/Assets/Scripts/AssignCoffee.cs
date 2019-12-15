using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class AssignCoffee : MonoBehaviour
{
    public String cust1 = "";
    public String cust2 = "";
    public String cust3 = "";
    public String cust4 = "";
    public String cust5 = "";
    public int index;
    Random rand = new Random();

    public String[] orders;

    public bool coffee1;
    


// Start is called before the first frame update
    void Awake()
    {
        
        orders = new string[3]{"black","foam","milk"};
        
        index = rand.Next(orders.Length);
        cust1 = orders[index];
        Debug.Log("customer 1 has order " + cust1);
        index = rand.Next(orders.Length);
        cust2 = orders[index];
        Debug.Log("customer 2 has order " + cust2);
        index = rand.Next(orders.Length);
        cust3 = orders[index];
        Debug.Log("customer 3 has order " + cust3);
        index = rand.Next(orders.Length);
        cust4 = orders[index];
        Debug.Log("customer 4 has order " + cust4);
        index = rand.Next(orders.Length);
        cust5 = orders[index];
        Debug.Log("customer 5 has order " + cust5);
    }

    // Update is called once per frame
    void Update()
    {/*
        if (cust1 == "foam"//coffee on table string)
        {
            coffee1 = true;
        }
        if (cust2 == //coffee on table string)
        {
            coffee2 = true;
        }
        if (cust3 == //coffee on table string)
        {
            coffee3 = true;
        }
        if (cust4 == //coffee on table string)
        {
            coffee4 = true;
        }
        if (cust5 == //coffee on table string)
        {
            coffee5 = true;
        }*/
    }
}