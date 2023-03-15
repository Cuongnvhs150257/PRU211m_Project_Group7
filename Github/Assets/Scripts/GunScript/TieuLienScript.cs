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
    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = getNearestEnemy();
        if(enemy != null)
        {
            Vector2 direction = enemy.transform.position - transform.position;
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
                //Debug.Log("addforce ne: " + (targetObject.transform.position - transform.position));
                shot.GetComponent<Rigidbody2D>().AddForce((nongsung.transform.position - transform.position) * 10, ForceMode2D.Impulse);
                timer = 0;
            }
        }
        
    }

    GameObject getNearestEnemy()
    {
        float currentDistance = float.MaxValue;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemies");
        GameObject targetEnemy = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject obj = enemies[i];
            float objectDistance = Vector3.Distance(transform.position, obj.transform.position);
            if (objectDistance < currentDistance)
            {
                targetEnemy = obj;
                currentDistance = objectDistance;
            }
        }
        return targetEnemy;
    }

}
