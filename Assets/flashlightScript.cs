using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightScript : MonoBehaviour
{
    public GameObject flashlight;
    bool flashlightStatus = false;
    bool recentFlicker = false;

    // min = inclusive, max = exclusive
    int randomNumber;
    float randomNumberFlicker;
    float randomNumberRecovery = 5f;

    int flickerCounter = 0;
    int flickerChance = 0;
    bool flickerPrevention = false;
    int flickerCooldown = 0;

    bool possibleMalfunction = false;
    int randomMalfunction;

    void Start()
    {
            flashlight = transform.GetChild(0).gameObject;
            Debug.Log(flashlight.name);
    }

    void Update()
    {
        flickerChance = 4;

        // Flashlight Hotkey
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

        // While flashlight is on OR a recent flicker has happened
        if (flashlightStatus || recentFlicker)
        {
            randomNumber = Random.Range(0, 26 - flickerChance); // 4% chance for a flicker per frame

            if (randomNumber == 0f && flickerPrevention == true)
            {
                flickerCounter--;
                randomNumberRecovery--;
                flickerCooldown++;
                if (flickerCounter == 0)
                {
                    flickerPrevention = false;
                }
            }

            if (randomNumber == 0f && flickerPrevention == false) // Trigger flicker
            {
                flashlightStatus = false;
                recentFlicker = true;
                flickerCounter++;
            }
            else if (recentFlicker) // 20% chance to recover per frame after flicker
            {

                randomNumberFlicker = Random.Range(0, 5);

                if (flickerCounter == randomNumberRecovery) // Will cancel the next x flickers
                {
                    if (flickerCounter > 0)
                    {
                            flickerPrevention = true;
                    }  
                }

                if (randomNumberFlicker == 0f)
                {
                    flashlightStatus = true;
                    recentFlicker = false;
                }

                if (randomNumberRecovery == 0) // Once recovery number reaches 0, refresh with a new random variable
                {
                    randomNumberRecovery = Random.Range(6, 12);
                }
            }

            if (flickerCounter > randomNumberRecovery) // Failsafe
            {
                flickerCounter -= flickerCounter;
            }

            if (flickerCooldown > 25) // Upon preventing 25 flickers, enter a cooldown state for 25 flickers. During this state, the flashlight can malfunction.
            {
                flickerCooldown = -25;
                randomNumberRecovery = 25;
                flickerCounter = 25;
            }

            if (flickerCooldown < 0)
            {
                possibleMalfunction = true;
            } 
            else
            {
                possibleMalfunction = false;
            }

            if (possibleMalfunction)
            {
                randomMalfunction = Random.Range(0, 1001);
                if (randomMalfunction == 0)
                {
                    possibleMalfunction = false;
                    flashlightStatus = false;
                }
            }


        }
            flashlight.SetActive(flashlightStatus);

    }
}
