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
        AudioListener.volume = 0;
    }


    // Update is called once per frame
    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        AudioListener.volume = 0.3f;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleVolumeButtonOnClickEvent()
    {
        SceneManager.LoadScene("VolumeMenu");
    }

    public void HandleSaveButtonOnClickEvent()
    {
        try
        {
            GameObject getSave = GameObject.FindGameObjectWithTag("Player");
            int levelIndex = getSave.transform.GetComponent<ManageLevel>().level;
            PlayerPrefs.SetInt("score", levelIndex);

            float healthIndex = getSave.transform.GetComponent<Healthmanage>().healthAmount;
            PlayerPrefs.SetFloat("health", healthIndex);

            float timeIndex = getSave.transform.GetComponent<TimerMenu>().deltaTime;
            PlayerPrefs.SetFloat("time", timeIndex);

            float postionXIndex = getSave.transform.GetComponent<Player>().postion.x;
            Debug.Log(postionXIndex);
            PlayerPrefs.SetFloat("postionX", postionXIndex);

            float postionYIndex = getSave.transform.GetComponent<Player>().postion.y;
            PlayerPrefs.SetFloat("postionY", postionYIndex);

            PlayerPrefs.Save();

            Destroy(gameObject);
            Time.timeScale = 0;
            SceneManager.LoadScene("Menu");
        }
        catch (System.Exception)
        {

            Debug.Log("Save Loi");
        }
    }
}
