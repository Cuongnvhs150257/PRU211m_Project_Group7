using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieuLienProperties : MonoBehaviour
{
    // Start is called before the first frame update
    int dame = 1;
    [SerializeField]
    GameObject sungTieuLien;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }

}
