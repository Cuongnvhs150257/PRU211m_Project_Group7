using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    public Text timeGame;
    public Text levelGame;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0.2f;

        GameObject getScore = GameObject.FindGameObjectWithTag("Player");
        timeGame.text = "Survival time: " + getScore.transform.GetComponent<TimerMenu>().time.ToString();

        levelGame.text = "Your Level: " + getScore.transform.GetComponent<ManageLevel>().level.ToString();
    }

    public void HandleRestartButtonOnClickEvent()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }
}
