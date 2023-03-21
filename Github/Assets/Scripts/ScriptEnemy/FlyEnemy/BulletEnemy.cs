using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletEB;

    public bool Friezel;

    public int dame = 5;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }
    // Start is called before the first frame update

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (Friezel)
        {
            speed = 0;
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                Friezel = false;
                speed = 10;
                timer = 0;
            }
        }
        else
        {
            speed = 10;
        }

        bulletEB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletEB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }


    private void Update()
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
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject takedame = GameObject.FindGameObjectWithTag("Player");
            takedame.GetComponent<Healthmanage>().healthAmount -= dame;
            if (takedame.GetComponent<Healthmanage>().healthAmount <= 0)
            {
                MenuManager.GoToMenu(MenuName.End);
            }
            Destroy(gameObject);
        }
    }

}