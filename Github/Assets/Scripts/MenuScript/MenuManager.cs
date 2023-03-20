using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                SceneManager.LoadScene("Menu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("Pause"));
                break;
            case MenuName.Volume:
                Object.Instantiate(Resources.Load("Volume"));
                break;
            case MenuName.End:
                Object.Instantiate(Resources.Load("End"));
                break;
        }
    }
}
