using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonDownScript : MonoBehaviour
{
    public bool retrySelected = false;
    public bool menuSelected = false;
    public static buttonDownScript instance;

    public GameObject monsterObject;

    public Button m_retryButton, m_menuButton;

    Vector3 monsterStartingPos;
    Vector3 playerStartingPos;
    float time = 0.1f;

    void Start()
    {
        instance = this;
        m_retryButton.onClick.AddListener(Retry);
        m_menuButton.onClick.AddListener(Menu);
        monsterStartingPos = MoveTo.instance.transform.position;
        playerStartingPos = playerMovement.instance.transform.position;
    }


    void Retry()
    {
        retrySelected = true;

        if (retrySelected)
        {
            SceneManager.LoadScene("MainGame");
        }
    }


    void Menu()
    {
        menuSelected = true;
    }
}
