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
        StartCoroutine(AttackPlayer());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 40)
        {
            hp += 30;
            maxHp+=30;
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
    public int attack = 10;
    public float attackSpeed = 1f;

    private IEnumerator AttackPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackSpeed);
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Healthmanage>().takeDamage(Damage);
            Debug.Log("Quái v?t t?n công ng??i ch?i và tr? " + attack + " ?i?m máu");
        }
    }

}
