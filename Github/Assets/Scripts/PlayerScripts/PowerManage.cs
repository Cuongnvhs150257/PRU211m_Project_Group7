using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManage : MonoBehaviour
{
    public GameObject vongNo;
    float timer;
    public bool isPower;
    int count;

    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    // Start is called before the first frame update
    void Start()    
    {
        count = 0;
        vongNo.SetActive(false);
        isPower = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPower == true)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                isPower = false;
                timer = 0;
                count = 0;
            }
        }
        if (count == 3)
        {
            vongNo.SetActive(true);
            isPower = true;
        }
    }
}
