using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 2f;
    // public Vector3 Offset = new Vector3(0, 8, 0);            // why does offset not work??? I have to set it directly, can't use variable.
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        // this.transform.localPosition += Offset;
        this.transform.localPosition += new Vector3(0,5,0);

        //  Debug.Log("Local Y: " + this.transform.localPosition.y);
    }

}
