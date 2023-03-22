using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageEnemy : MonoBehaviour
{
    int hp;
    int damage;
    float timer;
    public int Dame
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        hp = 0;
        damage = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > 60)
        {
            hp += 25;
            damage++;
            timer = 0;
        }
    }
}
