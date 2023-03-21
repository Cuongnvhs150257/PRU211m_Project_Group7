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
        AudioListener.volume = 0.3f;
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void HandleAudioButtonClickEvent()
    {
        PlayerPrefs.SetInt("audioback", 1);

        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Volume);
    }

    public void HandleLoadButtonOnClickEvent()
    {
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
