using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Cooking : MonoBehaviour
{
    public float requiredCookTime = 5;
    private float CookTimer; 
    public Slider CookBar;
    // public KeyCode activateKey;

    [SerializeField]
    public UnityEvent LongClick;



    void Start()
    {
        CookTimer = 0;
        CookBar.value = CalcCook();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(activateKey))
        // {
        //     Debug.Log("Key Down");
        //     CookTimer += Time.deltaTime;
        //     CookBar.value = CalcCook();
        //     if(CookTimer >= requiredCookTime)
        //     {
        //         if(LongClick != null)
        //         {
        //             LongClick.Invoke();
        //         }
        //         Reset();
        //     }

        // }
        // else
        // {
        //     Reset();
        //     // Debug.Log("Key Up");
        // }
        
    }

    public void Cook(KeyCode cookKey)
    {
        if(Input.GetKey(cookKey))
        {
            Debug.Log("Key Down");
            CookTimer += Time.deltaTime;
            CookBar.value = CalcCook();
            if(CookTimer >= requiredCookTime)
            {
                if(LongClick != null)
                {
                    LongClick.Invoke();
                }
                Reset();
            }

        }
        else
        {
            Reset();
            // Debug.Log("Key Up");
        }
    }

    private float CalcCook()
    {
        return CookTimer / requiredCookTime;
    }
    private void Reset()
    {
        CookTimer = 0;
        CookBar.value = CalcCook();
    }
}
