//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;


public class AssignCoffee : MonoBehaviour
{
    public string cust1 = "";
    public string cust2 = "";
    public string cust3 = "";
    public string cust4 = "";
    public string cust5 = "";
    public int index;
    //Random rand = new Random();

    public string[] orders;

    public GameObject table1;
    public GameObject table2;
    public GameObject table3;
    public GameObject table4;
    public GameObject table5;

    //public bool coffee1;


    // Start is called before the first frame update
    void Awake()
    {

        orders = new string[3] { "black", "foam", "milk" };

        index = Random.Range(0, orders.Length);
        //cust1 = "empty";
        cust1 = orders[index];
        Debug.Log("customer 1 has order " + cust1);
        index = Random.Range(0, orders.Length);
        //cust2 = "empty";
        cust2 = orders[index];
        Debug.Log("customer 2 has order " + cust2);
        index = Random.Range(0, orders.Length);
        //cust3 = "empty";
        cust3 = orders[index];
        Debug.Log("customer 3 has order " + cust3);
        index = Random.Range(0, orders.Length);
        //cust4 = "empty";
        cust4 = orders[index];
        Debug.Log("customer 4 has order " + cust4);
        index = Random.Range(0, orders.Length);
        //cust5 = "empty";
        cust5 = orders[index];
        Debug.Log("customer 5 has order " + cust5);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Coffee status: " + table1.GetComponent<Table>().status);
        if (table1.GetComponent<Table>().status == cust1)
        {
            Debug.Log("cust1");
            GetComponent<Customer>().coffee1 = true;
            table1.GetComponent<Table>().status = "";
        }
        if (table2.GetComponent<Table>().status == cust2)
        {
            Debug.Log("cust2");
            GetComponent<Customer>().coffee2 = true;
            table2.GetComponent<Table>().status = "";
        }
        if (table3.GetComponent<Table>().status == cust3)
        {
            Debug.Log("cust3");
            GetComponent<Customer>().coffee3 = true;
            table3.GetComponent<Table>().status = "";
        }
        if (table4.GetComponent<Table>().status == cust4)
        {
            Debug.Log("cust4");
            GetComponent<Customer>().coffee4 = true;
            table4.GetComponent<Table>().status = "";
        }
        if (table5.GetComponent<Table>().status == cust5)
        {
            Debug.Log("cust5");
            GetComponent<Customer>().coffee5 = true;
            table5.GetComponent<Table>().status = "";
        }
    }
}