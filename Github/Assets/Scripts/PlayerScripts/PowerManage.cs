using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManage : MonoBehaviour
{
    public GameObject vongNo;
    float timer;
    public bool isPower;
    int count;
    float timer2;

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
            GameObject takedame = GameObject.FindGameObjectWithTag("Player");
            //takedame.GetComponent<JoyStickMove>().velociad += 1;
            
            takedame.GetComponent<BaseDame>().BaseDamage = takedame.GetComponent<BaseDame>().PowerBaseDamage;
            int x = takedame.GetComponent<BaseDame>().BaseDamage;
            Debug.Log("Tang BaseDame: " + x);
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                isPower = false;
                timer = 0;
                count = 0;
                vongNo.SetActive(false);
                //takedame.GetComponent<JoyStickMove>().velociad -= 2;
                takedame.GetComponent<BaseDame>().BaseDamage /= 2;
                int y = takedame.GetComponent<BaseDame>().BaseDamage;
                Debug.Log("Giam BaseDame: " + y);


            }
        }
        if (count == 7)
        {          
                vongNo.SetActive(true);
                isPower = true;                         
        }
    }
}
