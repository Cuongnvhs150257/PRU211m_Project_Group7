 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFollowPlayer : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    private Transform target;
    public bool Friezel;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Friezel = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Friezel)
        {
            speed = 0;
            timer += Time.deltaTime;
            if(timer >= 3)
            {
                speed = 0.9f;
                timer = 0;
            }
        }
        else
        {
            speed = 0.9f;
        }
        if (Vector2.Distance(transform.position, target.position) > 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
