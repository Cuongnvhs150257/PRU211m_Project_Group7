using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthmanage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healBar;

    public float healthAmount = 30f;
    public float maxHealth = 30f;

    public bool shieldActivated = false;

    public bool addHealth = false;

    public float dame = 10;

    float timer;

    [SerializeField]
    GameObject player;
    public Text healText;
    // Start is called before the first frame update
    void Start()
    {
        float healthIndex = PlayerPrefs.GetFloat("health");
        float maxhealthIndex = PlayerPrefs.GetFloat("maxhealth");
        if (healthIndex > 0)
        {
            healthAmount = healthIndex;
            maxHealth = maxhealthIndex;
        }

        healText.text = "HP: " + healthAmount.ToString() + "/" + maxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healBar.fillAmount = healthAmount / maxHealth;

        healText.text = "HP: " + healthAmount.ToString() + "/" + maxHealth.ToString();
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
            if (timer >= 5)
            {
                shieldActivated = false;
                dame = 10;
                timer = 0;
                Debug.Log("het khien");
            }
        }
        else
        {
            dame = 10;
        }

        if (addHealth == true)
        {
            Heal(10);
            addHealth = false;
        }

    }
    public void takeDamage(float dame)
    {
        if (shieldActivated == false)
        {
            healthAmount -= dame;
            if (healthAmount <= 0)
            {
                MenuManager.GoToMenu(MenuName.End);
            }
        }
        else
        {
            dame = 0;
        }
       

    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);

    }




    ////////////////
    //public int attack = 10;
    //public float attackSpeed = 1f;
    //public bool isAttacking = false;

    //public void OnCollisionEnter2D(Collision2D other)
    //{
    //    isAttacking = true;
    //    if (other.gameObject.CompareTag("enemies"))
    //    {
    //        if (isAttacking)
    //        {
    //            EnemyProperties enemy = other.gameObject.GetComponent<EnemyProperties>();
    //            if (enemy != null)
    //            {
    //                int enemyDame = enemy.Damage;
    //                StartCoroutine(AttackPlayer(other.gameObject));
    //            }
    //        }
            

    //    }
    //    if (other.gameObject.CompareTag("testheal"))
    //    {
    //        Heal(10);
    //    }
    //}




    //public IEnumerator AttackPlayer(GameObject enemy)
    //{

    //    do
    //    {
    //        int enemyDamage = enemy.GetComponent<EnemyProperties>().Damage;
    //        takeDamage(enemyDamage);
    //        yield return new WaitForSeconds(attackSpeed);

    //    }
    //    while (isAttacking == true);

    //}

    //public void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("enemies"))
    //    {
    //        // N?u ng??i ch?i r?i kh?i vùng va ch?m, d?ng tr? máu
    //        StopCoroutine(AttackPlayer(other.gameObject));
    //        isAttacking = false;

    //    }
    //}
   

}

