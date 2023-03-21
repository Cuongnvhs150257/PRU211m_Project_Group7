using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerMenu : MonoBehaviour
{
    public Text MyscoreText;

    public float deltaTime;

    public string formattedTime;

    // Start is called before the first frame update
    void Start()
    {
        float timeIndex = PlayerPrefs.GetFloat("time");
        if (timeIndex > 0)
        {
            deltaTime = timeIndex;
            int minutes = Mathf.FloorToInt(deltaTime / 60f);
            int seconds = Mathf.FloorToInt(deltaTime % 60f);
            formattedTime = minutes.ToString("00") + ":" + seconds.ToString("00");
            MyscoreText.text = formattedTime;
        }
        else
        {
            MyscoreText.text = "00:00";
        }

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(deltaTime / 60f);
        int seconds = Mathf.FloorToInt(deltaTime % 60f);
        formattedTime = minutes.ToString("00") + ":" + seconds.ToString("00");

        MyscoreText.text = formattedTime;

    }
}
