using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageLevel : MonoBehaviour
{
    public Text levelCount;
    public int exp=0;
    public int nextLv=10;
    public int level=1;

    public int Exp
    {
        get { return exp; }
        set { exp = value; }
    }

    public int NextLv
    {
        get { return nextLv; }
        set { nextLv = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    void Start()
    {
        level = 1;
        nextLv = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= nextLv)
        {
            int rs = exp - nextLv;//so du exp
            level++;
            nextLv += 5;
            exp = rs;
            Debug.Log("Tang cap: " +level);
            levelCount.text = level.ToString();
        }
        Debug.Log("Exp hien tai: " + exp+ " - Level: "+level);
        
    }
}