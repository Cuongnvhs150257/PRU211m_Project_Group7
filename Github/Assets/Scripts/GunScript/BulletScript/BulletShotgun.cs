using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotgun : MonoBehaviour
{
    public int dame = 5;
    public int level;
    bool upLevel2 = true;
    bool upLevel3 = true;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    // Start is called before the first frame update
    private float timer;
    private float timer2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
        if (mainCharacter.GetComponent<ManageLevel>().Level == 25 && upLevel2 == true)
        {
            level++;
            upLevel2 = false;
            Debug.Log("Update level 2");
        }
        if (mainCharacter.GetComponent<ManageLevel>().Level == 40 && upLevel3 == true)
        {
            level++;
            upLevel3 = false;
            Debug.Log("Update level 3");
        }
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
            timer = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (other.gameObject.CompareTag("enemies"))
        {
            //tru di dame cua sung
            obj.GetComponent<EnemyProperties>().Hp -= (dame * level);
            if (obj.gameObject.GetComponent<EnemyProperties>().Hp <= 0)
            {
                
                
                GameObject takedame = GameObject.FindGameObjectWithTag("Player");
                takedame.GetComponent<PowerManage>().Count++;
                takedame.GetComponent<ManageLevel>().Exp += obj.gameObject.GetComponent<EnemyProperties>().Exp;
                Destroy(obj.gameObject);
            }

            //destroy bullet
            Destroy(gameObject);
        }
    }
}
