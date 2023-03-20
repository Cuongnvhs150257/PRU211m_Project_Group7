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
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    public void HandleVolumeButtonOnClickEvent()
    {
        SceneManager.LoadScene("VolumeMenu");
    }
}
