using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieuLienScript : MonoBehaviour
{
    private Camera mainCam;
    public GameObject bullet;
    public Transform bulletTransform;
    public Transform nongsung;
    public bool canFire;
    private float timer;
    public static float timeBetweenFire = 1f;
    private Rigidbody2D rb;
    Vector2 spawnLocation = Vector2.zero;
    //enemy
    public Transform targetObject;
    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
            Debug.Log("addforce ne: " + (targetObject.transform.position - transform.position));
            shot.GetComponent<Rigidbody2D>().AddForce((nongsung.transform.position - transform.position) * 10, ForceMode2D.Impulse);
            timer = 0;
        }


        //if (Input.GetAxis("Shooting") > 0 && canFire)
        //{
        //    canFire = false;
        //    GameObject shot = Instantiate<GameObject>(bullet, transform.position, bulletTransform.localRotation);
        //    shot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, oppositeAngle));
        //    Debug.Log("addforce ne: " + (targetObject.transform.position - transform.position));
        //    shot.GetComponent<Rigidbody2D>().AddForce((nongsung.transform.position - transform.position) * 10, ForceMode2D.Impulse);
        //}
    }

}
