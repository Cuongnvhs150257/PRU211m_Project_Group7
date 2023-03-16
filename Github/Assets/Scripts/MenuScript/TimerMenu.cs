using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerMenu : MonoBehaviour
{
    public Text MyscoreText;

    float deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        MyscoreText.text = "00:00";

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        int time=(int)deltaTime;
        MyscoreText.text = "00:" + time.ToString();

    }
}
