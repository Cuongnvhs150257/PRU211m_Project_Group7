using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonClickEvent()
    {
        AudioListener.volume = 0.5f;
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void HandleAudioButtonClickEvent()
    {
        SceneManager.LoadScene("VolumeMenu");
    }

    public void HandleQuitButtonClickEvent()
    {
        Application.Quit();
    }
}
