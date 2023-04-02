using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinButtonScript : MonoBehaviour
{
    public Button m_menuButton;


    void Start()
    {
        m_menuButton.onClick.AddListener(Menu);
        Cursor.lockState = CursorLockMode.None;
    }
    void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
