using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Volume);
    }

    public void HandleLoadButtonOnClickEvent()
    {
        SceneManager.LoadScene("GamePlay");
        
    }

    public void HandleQuitButtonClickEvent()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
