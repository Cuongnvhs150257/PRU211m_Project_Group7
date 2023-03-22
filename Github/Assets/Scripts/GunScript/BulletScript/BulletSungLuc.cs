using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSungLuc : MonoBehaviour
{   
    private float timer;
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
            //base dame main character
            GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
            int baseDamage = mainCharacter.GetComponent<BaseDame>().BaseDamage;
            //damage and level of gun
            GameObject sungLuc = GameObject.FindGameObjectWithTag("sungluc");
            int bulletDame = sungLuc.GetComponent<SunglucScript>().Dame;
            int levelGun = sungLuc.GetComponent<SunglucScript>().Level;

            obj.GetComponent<EnemyProperties>().Hp -= ((bulletDame * levelGun) + baseDamage);
            Debug.Log("Dame gay ra: " + ((bulletDame * levelGun) + baseDamage));
            if (obj.gameObject.GetComponent<EnemyProperties>().Hp <= 0)
            {
                mainCharacter.GetComponent<PowerManage>().Count++;
                mainCharacter.GetComponent<ManageLevel>().Exp += obj.gameObject.GetComponent<EnemyProperties>().Exp;
                Destroy(obj.gameObject);
            }

            //destroy bullet
            Destroy(gameObject);
        }
    }
}
