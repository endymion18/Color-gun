using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Options : MonoBehaviour

{
    public TMP_Dropdown  resolutionDropdown;
    [SerializeField] private AudioMixer audioMixer;

    public void SetMusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Music",Mathf.Log10(sliderValue) * 20);
    }
    
    public void SetSoundsVolume(float sliderValue)
    {
        audioMixer.SetFloat("Sound", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Sound",Mathf.Log10(sliderValue) * 20);
    }
    
    
    public void ChangeResolutions()
    {
        if (resolutionDropdown.value == 0)
        {
            Screen.SetResolution(1024, 768, true);
        }
        else if (resolutionDropdown.value == 1)
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if (resolutionDropdown.value == 2)
        {
            Screen.SetResolution(1366,768,true);
        }
        else if(resolutionDropdown.value == 3)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if(resolutionDropdown.value == 4)
        {
            Screen.SetResolution(2560, 1440, true);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ExitOptions()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.GetFloat("Music");
        PlayerPrefs.GetFloat("Sound");
    }
}
