using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public float timer = 0;

    public bool shouldMove = true;
    
    public GameObject Ghost1;
    public GameObject Ghost2;
    public GameObject Ghost3;
    public GameObject Ghost4;
    public GameObject Ghost5;
    
    
    public GameObject Table1;
    public GameObject Table2;
    public GameObject Table3;
    public GameObject Table4;
    public GameObject Table5;

    public GameObject exit1;
    
    public bool coffee1 = false;
    public bool coffee2 = false;
    public bool coffee3 = false;
    public bool coffee4 = false;
    public bool coffee5 = false;

    private Transform target1;
    private Transform target2;
    private Transform target3;
    private Transform target4;
    private Transform target5;
    private Transform exit;

    public int score = 0;
    void Awake()
    {

        target1 = Table1.transform;
        target2 = Table2.transform;
        target3 = Table3.transform;
        target4 = Table4.transform;
        target5 = Table5.transform;
        exit = exit1.transform;

    }
    
    void Update()
    {
        if (score < 2)
        {
            levelOne();
        }

        if (score > 2)
        {
            levelTwo();
        }

    }
    
    
    void checkCoffee1()
    {
        if (coffee1 == true)
        {
            
            Ghost1.transform.position = Vector3.MoveTowards(Ghost1.transform.position, exit.position, 0.01f);
        }

        if (coffee1 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 300.0f;
            if (timer > waitTime)
            {
                Ghost1.transform.position = Vector3.MoveTowards(Ghost1.transform.position, exit.transform.position, 0.01f);
            }
        }
    }
    
    void checkCoffee2()
    {
        if (coffee2 == true)
        { 
            Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, exit.position, 0.01f);
        }
        
        if (coffee2 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 300.0f;
            if (timer > waitTime)
            { 
                Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, exit.position, 0.01f);
            }

            else
            {
                Debug.Log(timer);
            }
        }
    }
    
    void checkCoffee3()
    {
        if (coffee3 == true)
        { 
            Ghost3.transform.position = Vector3.MoveTowards(Ghost3.transform.position, exit.position, 0.01f);
        }
        if (coffee3 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 300.0f;
            if (timer > waitTime)
            {
                Ghost3.transform.position = Vector3.MoveTowards(Ghost3.transform.position, exit.position, 0.01f);

            }

            else
            {
                Debug.Log(timer);
            }
        }
    }
    
    void checkCoffee4()
    {
        if (coffee4 == true)
        { 
            Ghost4.transform.position = Vector3.MoveTowards(Ghost4.transform.position, exit.position, 0.01f);
        }
        if (coffee4 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 300.0f;
            if (timer > waitTime)
            {
                Ghost4.transform.position = Vector3.MoveTowards(Ghost4.transform.position, exit.position, 0.01f);

            }

            else
            {
                Debug.Log(timer);
            }
        }
    }
    
    void checkCoffee5()
    {
        if (coffee5 == true)
        { 
            Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, exit.position, 0.01f);
        }
        if (coffee5 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 300.0f;
            if (timer > waitTime)
            {
                Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, exit.position, 0.01f);

            }

            else
            {
                Debug.Log(timer);
            }
        }
        
    }

    void levelOne()
    {
        float step =  3.0f * Time.deltaTime;
     
        Ghost1.transform.position = Vector3.MoveTowards(Ghost1.transform.position, target1.position, step);

        if (Vector3.Distance(Ghost1.transform.position, target1.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee1",0,1);
        }
        Ghost3.transform.position = Vector3.MoveTowards(Ghost3.transform.position, target3.position, step);
        
        if (Vector3.Distance(Ghost3.transform.position, target3.position) < 2.0f){
            InvokeRepeating("checkCoffee3",0,1);
    }
        
    }

    void levelTwo()
    {
        float step =  3.0f * Time.deltaTime; 
        Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, target5.position, step);
        Ghost4.transform.position = Vector3.MoveTowards(Ghost4.transform.position, target4.position, step);
        Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, target2.position, step);
        InvokeRepeating("checkCoffee2",0,1);
        InvokeRepeating("checkCoffee4",0,1);
        InvokeRepeating("checkCoffee5",0,1);
    }
    
    
}
