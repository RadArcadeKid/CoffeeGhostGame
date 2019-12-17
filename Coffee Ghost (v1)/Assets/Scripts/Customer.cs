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

    private bool move1 = false;
    private bool move2 = false;
    private bool move3 = false;
    private bool move4 = false;
    private bool move5 = false;

    private bool decremented1 = false;
    private bool decremented2 = false;
    private bool decremented3 = false;
    private bool decremented4 = false;
    private bool decremented5 = false;

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

        if (score >= 2 && score < 5)
        {
            timer = 0;
            levelTwo();
            decremented1 = false;
            decremented2 = false;
            decremented3 = false;
            decremented4 = false;
            decremented5 = false;
        }
        if (score >= 5)
        {
            timer = 0;
            levelThree();
            decremented1 = false;
            decremented2 = false;
            decremented3 = false;
            decremented4 = false;
            decremented5 = false;
        }
        Debug.Log("Score: " + score);

    }


    void checkCoffee1()
    {
        if (coffee1 == true)// score
        {
            score++;
            move1 = true;
            coffee1 = false;
        }
        if (move1)
        {
            Ghost1.transform.position = Vector3.MoveTowards(Ghost1.transform.position, exit.position, 0.01f);
        }
        if (Ghost1.transform.position == exit.position)
        {
            move1 = false;
        }

        if (coffee1 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 500.0f;
            if (timer > waitTime)
            {
                Ghost1.transform.position = Vector3.MoveTowards(Ghost1.transform.position, exit.transform.position, 0.01f);
                if (!decremented1)
                {
                    score--;
                    decremented1 = true;
                }

            }
        }
    }

    void checkCoffee2()
    {
        if (coffee2 == true)
        {
            move2 = true;
            score++;
            coffee2 = false;
        }
        if (move2)
        {
            Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, exit.position, 0.01f);
        }
        if (Ghost2.transform.position == exit.position)
        {
            move2 = false;
        }
        if (coffee2 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 500.0f;
            if (timer > waitTime)
            {
                Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, exit.position, 0.01f);
                if (!decremented2)
                {
                    score--;
                    decremented2 = true;
                }

            }

        }
    }

    void checkCoffee3()
    {
        if (coffee3 == true)
        {
            move3 = true;
            score++;
            coffee3 = false;
        }
        if (move3)
        {
            Ghost3.transform.position = Vector3.MoveTowards(Ghost3.transform.position, exit.position, 0.01f);
        }
        if (Ghost3.transform.position == exit.position)
        {
            move3 = false;
        }
        if (coffee3 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 500.0f;
            if (timer > waitTime)
            {
                Ghost3.transform.position = Vector3.MoveTowards(Ghost3.transform.position, exit.position, 0.01f);
                if (!decremented3)
                {
                    score--;
                    decremented3 = true;
                }

            }

        }
    }

    void checkCoffee4()
    {
        if (coffee4 == true)
        {
            move4 = true;
            score++;
            coffee4 = false;
        }
        if (move4)
        {
            Ghost4.transform.position = Vector3.MoveTowards(Ghost4.transform.position, exit.position, 0.01f);
        }
        if (Ghost4.transform.position == exit.position)
        {
            move4 = false;
        }
        if (coffee4 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 500.0f;
            if (timer > waitTime)
            {
                Ghost4.transform.position = Vector3.MoveTowards(Ghost4.transform.position, exit.position, 0.01f);
                if (!decremented4)
                {
                    score--;
                    decremented4 = true;
                }

            }

        }
    }

    void checkCoffee5()
    {
        if (coffee5 == true)
        {
            move5 = true;
            score++;
            coffee5 = false;
        }
        if (move5)
        {
            Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, exit.position, 0.01f);
        }
        if (Ghost5.transform.position == exit.position)
        {
            move5 = false;
        }
        if (coffee5 == false)
        {
            timer += Time.deltaTime;
            float waitTime = 500.0f;
            if (timer > waitTime)
            {
                Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, exit.position, 0.01f);
                if (!decremented5)
                {
                    score--;
                    decremented5 = true;
                }

            }

        }

    }

    void levelOne()
    {
        float step = 3.0f * Time.deltaTime;

        Ghost1.transform.position = Vector3.MoveTowards(Ghost1.transform.position, target1.position, step);

        if (Vector3.Distance(Ghost1.transform.position, target1.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee1", 0, 1);
        }
        Ghost3.transform.position = Vector3.MoveTowards(Ghost3.transform.position, target3.position, step);

        if (Vector3.Distance(Ghost3.transform.position, target3.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee3", 0, 1);
        }

    }

    void levelTwo()
    {
        float step = 3.0f * Time.deltaTime;
        Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, target5.position, step);
        if (Vector3.Distance(Ghost5.transform.position, target5.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee5", 0, 1);
        }
        Ghost4.transform.position = Vector3.MoveTowards(Ghost4.transform.position, target4.position, step);
        if (Vector3.Distance(Ghost4.transform.position, target4.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee4", 0, 1);
        }
        Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, target2.position, step);
        if (Vector3.Distance(Ghost2.transform.position, target2.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee2", 0, 1);
        }
    }

    void levelThree()
    {
        float step = 3.0f * Time.deltaTime;
        Ghost5.transform.position = Vector3.MoveTowards(Ghost5.transform.position, target5.position, step);
        if (Vector3.Distance(Ghost5.transform.position, target5.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee5", 0, 1);
        }
        Ghost2.transform.position = Vector3.MoveTowards(Ghost2.transform.position, target2.position, step);
        if (Vector3.Distance(Ghost2.transform.position, target2.position) < 2.0f)
        {
            InvokeRepeating("checkCoffee2", 0, 1);
        }

    }

}
