using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingUI : MonoBehaviour
{
    Cooking cook_script;
    Durability durab_script;
    
    // public Animator animator;
    public Slider durabSlider;
    public Slider cookSlider;
    public Image repairTimer;

    public bool op;


    void Start()
    {
        // AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        // Destroy(gameObject, clipInfo[0].clip.length);

        cook_script.CookBar = cookSlider;
        durab_script.durabilityBar = durabSlider;
        durab_script.fillImage = repairTimer;

        op = durab_script.operable;
        this.transform.localPosition = new Vector3(0, 0.5f, 0);


    }

    public void SetDurabSlider(KeyCode cookKey)
    {
        cook_script.Cook(cookKey);
    }
    public void SetCookSlider(KeyCode repairKey)
    {
        durab_script.Fix(repairKey);
    }

    public bool Durab_CheckDurability()
    {
        if(durab_script.DurabilityCheck())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
