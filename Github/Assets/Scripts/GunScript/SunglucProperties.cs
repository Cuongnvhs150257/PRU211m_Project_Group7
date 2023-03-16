using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunglucProperties : MonoBehaviour
{
    // Start is called before the first frame update
    int dame = 2;
    [SerializeField]
    GameObject shotgun;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }
}
