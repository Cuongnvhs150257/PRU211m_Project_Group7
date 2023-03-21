using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healBar;
    public int hp;
    public int damage;
    public int exp;

    public int maxHp;

    private float timer;

    private void Start()
    {
        timer = 0;
        //StartCoroutine(AttackPlayer());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 40)
        {
            hp += 30;
            maxHp += 30;
            damage++;
            timer = 0;
        }

        healBar.fillAmount = (float)hp / maxHp;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }

    public int MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int Exp
    {
        get { return exp; }
        set { exp = value; }
    }


    // try fix enemies attack Player
    //public int attack = 10;
    //public float attackSpeed = 1f;
    //public bool isAttacking = false;
    //public IEnumerator AttackPlayer(GameObject player)
    //{
    //    isAttacking = true;
    //    while (true)
    //    {
    //        player.GetComponent<Healthmanage>().takeDamage(Damage);
    //        yield return new WaitForSeconds(attackSpeed);

    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (!isAttacking)
    //        {
    //            // N?u ng??i ch?i r?i kh?i vùng va ch?m, d?ng tr? máu
    //            StopCoroutine(AttackPlayer(other.gameObject));
    //            isAttacking = false;
    //        }
    //    }

    //}
}
