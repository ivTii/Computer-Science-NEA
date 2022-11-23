using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightScript : MonoBehaviour
{
    public GameObject flashlight;
    bool flashlightStatus = false;
    bool flashlightFlicker = false;
    bool recentFlicker = false;
    float randomNumber;
    float randomNumberFlicker;

    void Start()
    {
            flashlight = transform.GetChild(0).gameObject;
            Debug.Log(flashlight.name);
    }

    void Update()
    {
        randomNumber = Random.Range(0, 49); // 2% chance to flicker per frame
        randomNumberFlicker = Random.Range(0, 4); // 20% chance to recover from flicker per frame

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

        if (flashlightStatus || recentFlicker)
        {
            randomNumber = Random.Range(0, 49);
            if (randomNumber == 22f)
            {
                flashlightStatus = false;
                recentFlicker = true;
            }
            else if (recentFlicker)
            {
                randomNumberFlicker = Random.Range(0, 4);
                if (randomNumberFlicker == 3f)
                {
                    flashlightStatus = true;
                    recentFlicker = false;
                }
            }
        }
            flashlight.SetActive(flashlightStatus);

    }
}
