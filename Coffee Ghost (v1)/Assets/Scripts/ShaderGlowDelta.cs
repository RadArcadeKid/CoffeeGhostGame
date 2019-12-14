using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PLACE THIS SCRIPT ON THE SAME OBJECT YOU PLACE THE SHADER? (I think)

public class ShaderGlowDelta : MonoBehaviour
{

    Renderer renderer;

    public float speedflash = 0.3f; //adjust how fast the object flashes with this 

    void Start()
    {
        renderer = GetComponent<Renderer>();

       // renderer.material.shader = Shader.Find("OUTLINE");
    }

    void Update()
    {
        // Animate the glow
        float glowyness = Mathf.PingPong( (Time.time*speedflash) , 0.15f) + 0.1f;
        renderer.material.SetFloat("_Outline", glowyness);
    }
}
