using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SettingsButtonScript : MonoBehaviour
{
    public Button m_Menu;
    public Toggle m_Flashlight, m_Camera, m_Brightness, m_Movement;
    public Slider m_Volume;

    public static SettingsButtonScript instance;

    public bool flashlight;
    public bool cameraGlitch;
    public bool brightness;
    public bool movement;
    public bool volume;

    private void Awake()
    {

    }
    void Start()
    {
        instance = this;

        m_Menu.onClick.AddListener(Menu);
        m_Flashlight.onValueChanged.AddListener(Flashlight);
        m_Camera.onValueChanged.AddListener(Camera);
        m_Brightness.onValueChanged.AddListener(Brightness);
        m_Movement.onValueChanged.AddListener(Movement);

        flashlight = flashlight;
        cameraGlitch = cameraGlitch;
        brightness = brightness;    
        movement = movement;   
        volume = volume;
    }

    public void Flashlight(bool arg1)
    {
        if (arg1)
        {
            flashlight = true;
        }
        else flashlight = false;
    }

    public void Camera(bool arg1)
    {
        if (arg1)
        {
            cameraGlitch = true;
        }
        else cameraGlitch = false;
    }

    public void Brightness(bool arg1)
    {
        if (arg1)
        {
            brightness = true;
        }
        else brightness = false;
    }

    public void Movement(bool arg1)
    {
        if (arg1)
        {
            movement = true;
        }
        else movement = false;
    }
    void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
