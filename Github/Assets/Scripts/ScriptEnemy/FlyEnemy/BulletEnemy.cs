using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletEB;


    public int dame = 5;
    //public int level;
    bool upLevel2 = true;
    bool upLevel3 = true;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }
    //public int Level
    //{
    //    get { return level; }
    //    set { level = value; }
    //}
    // Start is called before the first frame update

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);
        }
    }

}