using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour // TODO: make it so when the settings menu opens, you call AdjustAllSliders(); 
{
    private static VolumeControl _instance;

    //auto attach (call them this exactly in the editor)
    private Slider MainVolumeSlider;
    private Slider SFXVolumeSlider;
    private Slider MusicVolumeSlider;

    [SerializeField] private bool _menuSettingsImmediatelyVisible;
    public static VolumeControl Instance
    {
        get
        {
            if (_instance == null) Debug.Log("no audio manager");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance) Destroy(_instance);
        _instance = this;
    }

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("mainVolume");
        if (_menuSettingsImmediatelyVisible) AdjustAllSliders();
    }
    public void AdjustAllSliders() // call whenever sliders become visible onscreen
    {
        SetMainVolumeSlider(0.95f); // these are the default values if the player has not entered any yet
        SetSFXVolumeSlider(0.8f);
        SetMusicVolumeSlider(0.5f);
        PlayerPrefs.Save();
    }

    #region adjusting the sliders to the right position
    private void SetMusicVolumeSlider(float defaultValue)
    {
        MusicVolumeSlider = GameObject.Find("MusicVolumeSlider").GetComponent<Slider>();
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            MusicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            MusicVolumeSlider.value = defaultValue;
            PlayerPrefs.SetFloat("musicVolume", defaultValue);
            PlayerPrefs.Save();
        }
    }
    private void SetSFXVolumeSlider(float defaultValue)
    {
        SFXVolumeSlider = GameObject.Find("SFXVolumeSlider").GetComponent<Slider>();

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            SFXVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            SFXVolumeSlider.value = defaultValue;
            PlayerPrefs.SetFloat("sfxVolume", defaultValue);
            PlayerPrefs.Save();
        }
    }
    private void SetMainVolumeSlider(float defaultValue)
    {
        MainVolumeSlider = GameObject.Find("MainVolumeSlider").GetComponent<Slider>();

        if (PlayerPrefs.HasKey("mainVolume"))
        {
            MainVolumeSlider.value = PlayerPrefs.GetFloat("mainVolume");
            AudioListener.volume = MainVolumeSlider.value;
        }
        else
        {
            MainVolumeSlider.value = defaultValue;
            PlayerPrefs.SetFloat("mainVolume", defaultValue);
            PlayerPrefs.Save();
        }
    }
    #endregion
    #region Change volume on slider interaction
    public void ChangeMainVolume()
    {
        AudioListener.volume = MainVolumeSlider.value;
        PlayerPrefs.SetFloat("mainVolume", MainVolumeSlider.value);
        PlayerPrefs.Save(); // Remember to save changes
    }
    public void ChangeMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", MusicVolumeSlider.value);
        PlayerPrefs.Save(); // Remember to save changes
    }
    public void ChangeSFXVolume()
    {
        PlayerPrefs.SetFloat("sfxVolume", SFXVolumeSlider.value);
        PlayerPrefs.Save(); // Remember to save changes
    }
    #endregion
}
