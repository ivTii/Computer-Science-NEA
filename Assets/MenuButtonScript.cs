using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public Button m_playButton, m_settingsButton, m_howToPlayButton, m_exitButton;


    void Start()
    {
        m_playButton.onClick.AddListener(Play);
        m_settingsButton.onClick.AddListener(Settings);
        m_howToPlayButton.onClick.AddListener(HtP);
        m_exitButton.onClick.AddListener(Exit);
    }

    public void Update()
    {
        Debug.Log(SettingsButtonScript.instance.flashlight);
    }
    void Play()
    {
        SceneManager.LoadScene("MainGame");
    }


    void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    void HtP()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    void Exit()
    {
        Application.Quit();
    }
}
