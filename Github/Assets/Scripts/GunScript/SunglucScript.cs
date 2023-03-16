using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunglucScript : MonoBehaviour
{
    private Camera mainCam;
    public GameObject bullet;
    public Transform mainCharacter;
    public Transform nongsung;
    private float timer;
    private float timeBetweenFire = 1f;
    private Rigidbody2D rb;
    Vector2 spawnLocation = Vector2.zero;
    private float yPositionForRotate = 0.2188364f;
    private float xPosiotionForRotate = 0.1701825f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = getNearestEnemy();
        if (enemy != null)
        {
            Vector2 direction = enemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // Calculate the opposite angle
            float oppositeAngle = angle;
            // Set the rotation of this object to the opposite angle
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, oppositeAngle));

            if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            {
                Vector3 vtr = new Vector3(transform.localScale.x, -transform.localScale.y, 0);
                transform.localScale = new Vector3(xPosiotionForRotate, -yPositionForRotate, 0);
                Debug.Log("Ket qua: " + transform.localScale);
            }
            else
            {
                Vector3 vtr = new Vector3(transform.localScale.x, transform.localScale.y, 0);
                transform.localScale = new Vector3(xPosiotionForRotate, yPositionForRotate, 0);
            }


            timer += Time.deltaTime;
            if (timer >= timeBetweenFire)
            {
                GameObject shot = Instantiate<GameObject>(bullet, transform.position, mainCharacter.localRotation);
                shot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, oppositeAngle));
                shot.GetComponent<Rigidbody2D>().AddForce((nongsung.transform.position - transform.position) * 10, ForceMode2D.Impulse);
                timer = 0;
            }
        }
    }

    private GameObject getNearestEnemy()
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
