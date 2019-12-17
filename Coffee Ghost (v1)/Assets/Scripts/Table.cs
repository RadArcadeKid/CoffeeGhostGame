using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public string status;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coffee")
        {
            Destroy(collision.gameObject);
            status = collision.gameObject.GetComponent<CoffeeStatus>().GetStatus();
            //Debug.Log(status);
        }

        Debug.Log("Table collided with: " + collision.gameObject.name);
    }
}
