using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonClickEvent()
    {
        Destroy(gameObject);
        AudioListener.volume = 0.3f;
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void HandleAudioButtonClickEvent()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("VolumeMenu");
    }

    public void HandleQuitButtonClickEvent()
    {
        Application.Quit();
    }
}
