using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep4FollowPlayer : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    public bool Friezel;

    float timer;

    private Transform target;

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
            if (timer >= 3)
            {
                Friezel = false;
                speed = 0.5f;
                timer = 0;
            }
        }
        else
        {
            speed = 0.9f;
        }

        if (Vector2.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
