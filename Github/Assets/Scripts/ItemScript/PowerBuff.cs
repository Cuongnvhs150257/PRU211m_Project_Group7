using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEffect/PowerBuff")]
public class PowerBuff : ItemEffect
{
    public bool healthBuff;
    public bool shield;
    public bool friezel;

    public override void Activate(GameObject target)
    {
        if (healthBuff)
        {
            Debug.Log("Health ++");
        }else if (shield)
        {
            Debug.Log("Shield Activated");
        }
        else
        {
            Debug.Log("Friezel Activated");
        }
       
    }
}
