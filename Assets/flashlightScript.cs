using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightScript : MonoBehaviour
{
    public GameObject flashlight;
    bool flashlightStatus = false;

    void Start()
    {
            flashlight = transform.GetChild(0).gameObject;
            Debug.Log(flashlight.name);
    }

    void Update()
    {
        if (Input.GetButtonDown("Flashlight"))
        {
            if (flashlightStatus)
            {
                flashlightStatus = false;
            }
            else
            {
                flashlightStatus = true;
            }
        }

        flashlight.SetActive(flashlightStatus);
    }
}
