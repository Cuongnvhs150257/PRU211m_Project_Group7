using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProperties : MonoBehaviour
{
    // Start is called before the first frame update
    int dame = 5;
    [SerializeField]
    GameObject shotgun;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }
}
