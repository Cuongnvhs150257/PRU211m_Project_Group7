using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DontDetroy : MonoBehaviour
{


    void Awake()
    {
        LoadValues();
        DontDestroyOnLoad(transform.gameObject);
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        AudioListener.volume = volumeValue;
    }
}
