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
        baseDamage = 1;
        timer = 0;
        powerBaseDamge = 2 * baseDamage;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 25)
        {
            baseDamage += 1;
            powerBaseDamge = 2 * baseDamage;
            timer = 0;
            
        }
    }
}
