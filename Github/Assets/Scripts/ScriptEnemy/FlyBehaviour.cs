using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    private Rigidbody2D rb;
    Vector2 spawnLocation = Vector2.zero;
    //nhan vat chinh
    public Transform targetObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = targetObject.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Calculate the opposite angle
        float oppositeAngle = angle;
        // Set the rotation of this object to the opposite angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, oppositeAngle));

        timer += Time.deltaTime;
        if (timer >= 0.5)
        {
            GameObject shot = Instantiate<GameObject>(bullet, transform.position, bulletTransform.localRotation);
            shot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, oppositeAngle));
            //shot.transform.position = Vector2.MoveTowards(shot.transform.position, targetObject.position, 1 * Time.deltaTime);
            shot.GetComponent<Rigidbody2D>().AddForce((targetObject.transform.position - transform.position) * 1, ForceMode2D.Impulse);
            timer = 0;
        }
    }
}
