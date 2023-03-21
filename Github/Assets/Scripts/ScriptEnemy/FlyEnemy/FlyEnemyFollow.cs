using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyFollow : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    public bool Friezel;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
                speed = 1.9f;
                timer = 0;
            }
        }
        else
        {
            speed = 1.9f;
        }

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
      if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        } else if(distanceFromPlayer <= shootingRange && nextFireTime<Time.time){
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
