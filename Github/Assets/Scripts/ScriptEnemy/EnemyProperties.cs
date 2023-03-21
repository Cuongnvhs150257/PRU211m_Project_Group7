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
    public int attack = 10;
    public float attackSpeed = 1f;
    public bool isAttacking = false;

    public void OnCollisionEnter2D(Collision2D other)
    {
        isAttacking = true;
        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(AttackPlayer(other.gameObject));
        }
    }


    public IEnumerator AttackPlayer(GameObject player)
    {
        while (isAttacking == true)
        {
            player.GetComponent<Healthmanage>().takeDamage(Damage);
            yield return new WaitForSeconds(attackSpeed);

        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ng choi ra khoi vung va cham thi ngung tru mau
            StopCoroutine(AttackPlayer(other.gameObject));
            isAttacking = false;

        }
    }

}
