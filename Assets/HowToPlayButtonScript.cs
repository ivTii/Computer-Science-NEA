using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayButtonScript : MonoBehaviour
{
    public Button m_menuButton;


    void Start()
    {
        m_menuButton.onClick.AddListener(Menu);
    }
    void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
