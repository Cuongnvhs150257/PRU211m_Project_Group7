using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
}
