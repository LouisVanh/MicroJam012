using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    private Canvas _settings;
    private Canvas _menu = null;
    private bool _isInEndScreen = false;


    private void Start()
    {
        // make sure the settings canvas has the settings tag!
        _settings = GameObject.FindWithTag("Settings").GetComponent<Canvas>();
        _menu = GameObject.FindWithTag("Menu").GetComponent<Canvas>();
        _settings.enabled = false;
        _menu.enabled = false;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0)) // MAIN MENU
        {
            _menu.enabled = true;
        }
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isInEndScreen)
        {
            ToggleSettings();
        }
    }
    public void PlayGame()
    {
        //AudioManager.Instance.SaveSliders();
        //SceneManager.LoadScene(1);
        this.gameObject.GetComponent<LoadingScreen>().Canvas.SetActive(true);
        this.gameObject.GetComponent<LoadingScreen>().LoadGameScene();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame() // load menu scene
    {
        SceneManager.LoadScene(0);
        _menu.enabled = true;
        _settings.enabled = false;
    }

    public void ToggleSettings()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0)) // MAIN MENU
        {
            _menu.enabled = _settings.enabled ? true : false;
        }

        _settings.enabled = _settings.enabled ? false : true;
        Time.timeScale = _settings.enabled ? 0 : 1;

        VolumeControl.Instance.AdjustAllSliders();

        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0)) // NOT MAIN MENU
        {
            Cursor.lockState = _settings.enabled ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = _settings.enabled ? true : false;
        }
    }
    private void SetIsInEndScreen()
    {
        _isInEndScreen = true;
    }

    public void ChangeMain()
    {
        VolumeControl.Instance.ChangeMainVolume();
    }
    public void ChangeMusic()
    {
        VolumeControl.Instance.ChangeMusicVolume();
    }
    public void ChangeSFX()
    {
        VolumeControl.Instance.ChangeSFXVolume();
    }
}