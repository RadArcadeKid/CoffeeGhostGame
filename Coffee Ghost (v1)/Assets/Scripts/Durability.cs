using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Durability : MonoBehaviour
{
    private float maxDurability = 10;
    private float currDurability; 
    public bool operable;

    public Slider durabilityBar;

    public float requiredRepairTime = 3;
    private float repairTimer = 0;
    public float decayRate = 0.5f;
    [SerializeField]
    public Image fillImage;
    void Start()
    {
        operable = true;
        currDurability = maxDurability;
        durabilityBar.value = CalcDurability();

        fillImage.fillAmount = CalcFixTime();

        // Connect scripts to player specific and/or location
        // GameEvents.current.onMachineTriggerEnter +=
    }

    // Update is called once per frame
    void Update()
    {
        // Machine Durability
        //
        //

        // Decay
        if(currDurability > 0)
        {
            DealDamage(Time.deltaTime*decayRate);
        }

       
        // if(Input.GetKeyDown(KeyCode.X))     //test for durability dmg
        // {
        //     DealDamage(2);
        // }


        
    }

    private float CalcFixTime()
    {
        return repairTimer/requiredRepairTime;
    }

    private float CalcDurability()
    {
        return currDurability / maxDurability;
    }

    public bool DurabilityCheck()
    {
        if(currDurability < maxDurability)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void DealDamage(float dmgVal)
    {
        //Lower machine Durability
        currDurability -= dmgVal;
        durabilityBar.value = CalcDurability();

        // If Durability 0, inoperable till fixed
        if(currDurability <= 0)
        {
            Broke();
               
        }
    }

    // Between 45seconds and 2minutes, break the machine
    private void Broke()
    {
        currDurability = 0;
        operable = false;
        Debug.Log(" Machine inoperable ");
        
    }
    public void Fix(KeyCode repairKey)
    {  
        // Fix Machine
        if(Input.GetKey(repairKey))
        {
            Debug.Log("Repair Key Down");
            repairTimer += Time.deltaTime;
            fillImage.fillAmount = CalcFixTime();
            if(repairTimer >= requiredRepairTime)
            {
                currDurability = maxDurability;
                operable = true;
                Debug.Log(" Machine is fixed");
                Reset();
            }

        }
        else
        {
            Reset();
            Debug.Log("Repair Key Up");
        }
    }
    private void Reset()
    {
        repairTimer = 0;
        durabilityBar.value = CalcDurability();
        fillImage.fillAmount = CalcFixTime();
        // Debug.Log("Calculated Fix Time: " + CalcFixTime());
    }
}
