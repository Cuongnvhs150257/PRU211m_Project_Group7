using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeCycle : MonoBehaviour
{
    public int dame = 5;

    [SerializeField]
    GameObject mainCharacter;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
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
            obj.GetComponent<EnemyProperties>().Hp-= dame;
            if (obj.gameObject.GetComponent<EnemyProperties>().Hp <= 0)
            {
                Destroy(obj.gameObject);
                mainCharacter.GetComponent<ManageLevel>().Exp += obj.gameObject.GetComponent<EnemyProperties>().Exp;
                //xu li exp

                mainCharacter.GetComponent<PowerManage>().Count++;

                //dkien xhien vong no
                if (mainCharacter.GetComponent<PowerManage>().Count == 3)
                {
                    mainCharacter.GetComponent<PowerManage>().vongNo.SetActive(true);
                    mainCharacter.GetComponent<PowerManage>().isPower = true;
                }
                Debug.Log("Count: " + mainCharacter.GetComponent<PowerManage>().Count);

                if (mainCharacter.GetComponent<PowerManage>().isPower == true)
                {
                    timer2 += Time.deltaTime;
                    if (timer2 >= 10)
                    {
                        mainCharacter.GetComponent<PowerManage>().isPower = false;
                        timer2 = 0;
                        mainCharacter.GetComponent<PowerManage>().Count = 0;
                    }
                }
                


                var exp = mainCharacter.GetComponent<ManageLevel>().Exp;
                var nextLevel = mainCharacter.GetComponent<ManageLevel>().NextLv;
                if (exp >=nextLevel)
                {
                    int rs = exp - nextLevel;//so du exp
                    mainCharacter.GetComponent<ManageLevel>().Level++;
                    mainCharacter.GetComponent<ManageLevel>().levelCount.text = mainCharacter.GetComponent<ManageLevel>().Level.ToString();
                    Debug.Log("Level up: " + mainCharacter.GetComponent<ManageLevel>().Level);
                    mainCharacter.GetComponent<ManageLevel>().NextLv += 5;
                    mainCharacter.GetComponent<ManageLevel>().Exp = rs;
                    
                }
                
            }

            //destroy bullet
            Destroy(gameObject);
        }
    }
}
