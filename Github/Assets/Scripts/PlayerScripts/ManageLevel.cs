using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageLevel : MonoBehaviour
{
    public Image expBar;
    public Text levelCount;
    public int exp=0;
    public int nextLv=10;
    public int level=1;

    public int Exp
    {
        get { return exp; }
        set { exp = value; }
    }

    public int NextLv
    {
        get { return nextLv; }
        set { nextLv = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    void Start()
    {
        int levelIndex = PlayerPrefs.GetInt("score");
        if (levelIndex > 0) 
        {
            Debug.Log(levelIndex);
            level = levelIndex;
        }
        else
        {
            level = 1;
        }
        nextLv = 10;
        expBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        expBar.fillAmount =(float) exp / nextLv;
        if (exp >= nextLv)
        {
            int rs = exp - nextLv;//so du exp
            level++;
            nextLv += 5;
            exp = rs;
            
            levelCount.text = level.ToString();
            GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
            mainCharacter.GetComponent<Healthmanage>().maxHealth += 20;
            mainCharacter.GetComponent<Healthmanage>().healthAmount = mainCharacter.GetComponent<Healthmanage>().maxHealth;
            mainCharacter.GetComponent<Healthmanage>().healText.text = mainCharacter.GetComponent<Healthmanage>().healthAmount.ToString()
                               + "/" + mainCharacter.GetComponent<Healthmanage>().maxHealth.ToString();

        

        }
       
        
    }
}
