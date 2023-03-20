using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDame : MonoBehaviour
{
    public int baseDamage;
    float timer;
    public int BaseDamage
    {
        get { return baseDamage; }
        set { baseDamage = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 20)
        {
            baseDamage += 1;
            timer = 0;
            
        }
    }
}
