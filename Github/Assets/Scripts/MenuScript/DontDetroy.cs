using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DontDetroy : MonoBehaviour
{
    public AudioSource m_MyAudioSource;

    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        LoadValues();
        DontDestroyOnLoad(transform.gameObject);

        if (PlayerPrefs.HasKey("audioOn"))
        {
            m_MyAudioSource.Stop();
        }
        else
        {
            m_MyAudioSource.Play();
        }
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        AudioListener.volume = volumeValue;
    }
}
