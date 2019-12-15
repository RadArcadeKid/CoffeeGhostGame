using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childTrigger : MonoBehaviour
{


    void OnTriggerEnter(Collider c)
    {
        gameObject.GetComponentInParent<MachineTrig>().PullTrigger(c);
    }
}
