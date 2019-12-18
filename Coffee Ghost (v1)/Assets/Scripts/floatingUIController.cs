using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingUIController : MonoBehaviour
{
    private static floatingUI popUpUI;
    private static GameObject canvas;
    // public static GameObject FloatingUIPrefab;
    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popUpUI = Resources.Load<floatingUI>("Prefabs/UIBarParent");

        

    }


    public static void CreateFloatingUI(Transform location)
    {
        // floatingUI instance = Instantiate(FloatingUIPrefab, transform.position, Quaternion.identity, transform);
        // Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2 (location.position.x, location.position.y + 0.5f));

        // instance.transform.SetParent(canvas.transform, false);
        // instance.transform.position = screenPosition;
    }
// 
}
