using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonDownScript : MonoBehaviour
{
    public static buttonDownScript instance;

    public GameObject monsterObject;

    public Button m_retryButton, m_menuButton;


    void Start()
    {
        instance = this;
        m_retryButton.onClick.AddListener(Retry);
        m_menuButton.onClick.AddListener(Menu);
    }


    void Retry()
    {
            SceneManager.LoadScene("MainGame");
    }


    void Menu()
    {
            SceneManager.LoadScene("MainMenu");
    }
}
