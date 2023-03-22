using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDame : MonoBehaviour
{
    public int baseDamage;
    float timer;
    public int powerBaseDamge;

    public int BaseDamage
    {
        get { return baseDamage; }
        set { baseDamage = value; }
    }

    public int PowerBaseDamage
    {
        get { return powerBaseDamge; }
        set { powerBaseDamge = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        int basedameIndex = PlayerPrefs.GetInt("basedame");
        if (basedameIndex >= 0)
        {
            baseDamage = basedameIndex;
        }

        timer = 0;
        powerBaseDamge = 2 * baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 40)
        {
            baseDamage += 1;
           
            powerBaseDamge = 2 * baseDamage;
            timer = 0;
            
        }
        //Debug.Log("Dame hien tai: " + baseDamage);
    }
}
