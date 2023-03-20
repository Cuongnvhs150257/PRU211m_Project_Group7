using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public int damage;
    public int exp;
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
