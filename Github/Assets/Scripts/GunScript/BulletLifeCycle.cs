using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeCycle : MonoBehaviour
{
    public int dame = 5;
    public int Dame
    {
        get { return dame; }
        set { dame = value; }
    }
    // Start is called before the first frame update
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (other.gameObject.CompareTag("enemies"))
        {
            //tru di dame cua sung
            obj.gameObject.GetComponent<EnemyProperties>().Hp-= dame;
            if (obj.gameObject.GetComponent<EnemyProperties>().Hp <= 0)
            {
                Destroy(obj.gameObject);
            }

            //destroy bullet
            Destroy(gameObject);
        }
    }
}
