using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonClickEvent()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void HandleQuitButtonClickEvent()
    {
        Application.Quit();
    }
}
