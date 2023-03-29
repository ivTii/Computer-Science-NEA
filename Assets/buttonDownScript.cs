using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            // Disable the script or behavior that controls the monster's movement
            // This prevents it from moving to its target position immediately after teleporting back to its starting position
            MoveTo.instance.enabled = false;

            // Set the position of the playerMovement instance object directly
            playerMovement.instance.transform.position = playerStartingPos;

            // Set the position of the monster object directly
            Vector3 tempPos = monsterStartingPos;
            tempPos.y = monsterObject.transform.position.y; // Keep the same Y position
            monsterObject.transform.position = tempPos;

            retrySelected = false;
            MoveTo.instance.playerDeath = false;

            // Re-enable the script or behavior that controls the monster's movement
            // This allows it to resume normal movement once the Retry() function has completed
            MoveTo.instance.enabled = true;
        }
    }


    void Menu()
    {
        menuSelected = true;
    }
}
