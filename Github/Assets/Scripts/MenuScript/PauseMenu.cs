using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }


    // Update is called once per frame
    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        PlayerPrefs.SetInt("audioOn", 1);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleVolumeButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Volume);
    }

    public void HandleSaveButtonOnClickEvent()
    {
        try
        {
            GameObject getSave = GameObject.FindGameObjectWithTag("Player");
            int levelIndex = getSave.transform.GetComponent<ManageLevel>().Level;
            PlayerPrefs.SetInt("score", levelIndex);

            float healthIndex = getSave.transform.GetComponent<Healthmanage>().healthAmount;
            PlayerPrefs.SetFloat("health", healthIndex);

            float maxhealthIndex = getSave.transform.GetComponent<Healthmanage>().maxHealth;
            PlayerPrefs.SetFloat("maxhealth", maxhealthIndex);

            int basedameIndex = getSave.transform.GetComponent<BaseDame>().BaseDamage;
            PlayerPrefs.SetInt("basedame", basedameIndex);

            float timeIndex = getSave.transform.GetComponent<TimerMenu>().deltaTime;
            PlayerPrefs.SetFloat("time", timeIndex);

            float postionXIndex = getSave.transform.GetComponent<Player>().postion.x;
           
            PlayerPrefs.SetFloat("postionX", postionXIndex);

            float postionYIndex = getSave.transform.GetComponent<Player>().postion.y;

            PlayerPrefs.SetFloat("postionY", postionYIndex);

            PlayerPrefs.Save();

            Time.timeScale = 1;
            Destroy(gameObject);
        }
        catch (System.Exception)
        {

            Debug.Log("Save Loi");
        }
    }
}
