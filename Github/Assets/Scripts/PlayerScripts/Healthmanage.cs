using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthmanage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healBar;
    public float healthAmount = 100f;

    public bool shieldActivated = false;

    public float dame = 10;

    float timer;

    [SerializeField]
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            takeDamage(dame);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Heal(15);
        }

        if (shieldActivated == true)
        {
            dame = 0;
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                dame = 10;
                timer = 0;
            }
        }
        else
        {
            dame = 10;
        }

    }
    public void takeDamage(float dame)
    {
            
            healthAmount -= dame;
            healBar.fillAmount = healthAmount / 100f;

            if (healthAmount <= 0)
            {
                Time.timeScale = 0;
            }

    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healBar.fillAmount = healthAmount / 100;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemies"))
        {
            takeDamage(dame);
        }
        if (other.gameObject.CompareTag("testheal"))
        {
            Heal(10);
        }
    }
}