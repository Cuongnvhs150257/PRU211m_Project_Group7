using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerMenu : MonoBehaviour
{
    public Text MyscoreText;

    public float deltaTime;

    public int time;

    // Start is called before the first frame update
    void Start()
    {
        float timeIndex = PlayerPrefs.GetFloat("time");
        if (timeIndex > 0)
        {
            deltaTime = timeIndex;
            time = (int)deltaTime;
            MyscoreText.text = "00:" + time.ToString();
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
        time=(int)deltaTime;
        MyscoreText.text = "00:" + time.ToString();

    }
}
