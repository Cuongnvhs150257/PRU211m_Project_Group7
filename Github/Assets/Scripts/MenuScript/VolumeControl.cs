using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    public Slider volumeSlider;

    [SerializeField]
    public Text volumeText;


    void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");

    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void HandleBackButtonClickEvent()
    {
        

        if (PlayerPrefs.GetInt("audioback") == 1)
        {
            MenuManager.GoToMenu(MenuName.Main);
        }
        else
        {
            Destroy(gameObject);
            
        }


    }





}
