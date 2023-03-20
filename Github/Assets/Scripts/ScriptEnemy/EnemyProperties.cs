using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public int damage;
    public int exp;

    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 60)
        {
            hp++;
            damage++;
            timer = 0;
            //Debug.Log("Vua tang cap hp: " + hp);
            //Debug.Log("Vua tang cap damage:  " + damage);
        }

    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Exp
    {
        get { return exp; }
        set { exp = value; }
    }
}
