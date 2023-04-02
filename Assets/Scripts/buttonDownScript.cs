using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonDownScript : MonoBehaviour
{
    public static buttonDownScript instance;

    public GameObject monsterObject;

    public Button m_retryButton, m_menuButton, m_returnButton, m_menuButton2;


    void Start()
    {
        instance = this;
        m_retryButton.onClick.AddListener(Retry);
        m_menuButton.onClick.AddListener(Menu);
        m_menuButton2.onClick.AddListener(MenuTwo);
        m_returnButton.onClick.AddListener(Return);
    }


    void Retry()
    {
            SceneManager.LoadScene("MainGame");
    }


    void Menu()
    {
            SceneManager.LoadScene("MainMenu");
    }

    void MenuTwo()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Return()
    {
        Escape.instance.escapeScreenStatus = false;
    }
}
