using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public GameObject escapeScreen;

    public static Escape instance;

    public bool escapeScreenStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        escapeScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escapeScreen.SetActive(true);
            escapeScreenStatus = true;
        }

        if(escapeScreenStatus == false)
        {
            escapeScreen.SetActive(false);
        }
    }
}
