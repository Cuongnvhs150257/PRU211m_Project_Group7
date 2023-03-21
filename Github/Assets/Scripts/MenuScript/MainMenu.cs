using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button loadButton;

    public void HandlePlayButtonClickEvent()
    {
        PlayerPrefs.DeleteAll();
        Destroy(gameObject);
        Time.timeScale = 1;
        AudioListener.volume = 0.3f;
        SceneManager.LoadScene("GamePlay");
    }

    public void HandleAudioButtonClickEvent()
    {
        PlayerPrefs.SetInt("audioback", 1);
        PlayerPrefs.SetInt("audioOn", 1);

        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Volume);
    }

    public void HandleLoadButtonOnClickEvent()
    {
        AudioListener.volume = 0.3f;
        if (PlayerPrefs.HasKey("score"))
        {
            SceneManager.LoadScene("GamePlay");
        }
        else
        {
            loadButton.interactable = false;
        }
        
        
    }

    public void HandleQuitButtonClickEvent()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
