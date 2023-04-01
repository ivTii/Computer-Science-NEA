using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaDegen : MonoBehaviour
{
    // [DEGEN]
    public GameObject leftD;
    public GameObject rightD;

    // [REGEN]
    public GameObject leftR;
    public GameObject rightR;

    double control = 0;
    float add = (370f/8)/120;
    bool degenState = false;

    private float stamina;
    bool isSprinting;
    bool isExhausted;
    float exhaustedStatus;

    // Start is called before the first frame update
    void Start()
    {
        // [DEGEN]
        leftD = transform.Find("Left.d").gameObject;
        rightD = transform.Find("Right.d").gameObject;
        leftD.SetActive(true); 
        rightD.SetActive(true);

        // [REGEN]
        leftR = transform.Find("Left.i").gameObject;
        rightR = transform.Find("Right.i").gameObject;
        leftR.SetActive(false);
        rightR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        stamina = sprintingScript.instance.stamina;
        isSprinting = playerMovement.instance.isSprinting;
        isExhausted = sprintingScript.instance.isExhausted;
        exhaustedStatus = sprintingScript.instance.exhaustedStatus;

        leftR.transform.localPosition = leftD.transform.localPosition;
        rightR.transform.localPosition = rightD.transform.localPosition;

        if (stamina < 15 || stamina == 100) degenState = false;
        else degenState = true;

        if (stamina < 0) stamina = 0;

        if (isSprinting && stamina > 15) control++;

        if (degenState && isSprinting)
        {
            leftD.SetActive(true);
            leftD.transform.localPosition += new Vector3(add, 0, 0);
            rightD.SetActive(true);
            rightD.transform.localPosition += new Vector3((-1*add), 0, 0);

            leftR.SetActive(false);
            rightR.SetActive(false);

        } 
        else
        {
            if (playerMovement.instance.mapStatus == false)
            {
                leftD.SetActive(false);
                rightD.SetActive(false);

                if (isExhausted == false && isSprinting == false && exhaustedStatus < 1 && stamina > 15)
                {
                    control -= 0.5; // Lose control while regenerating
                    if (control < 0)
                    {
                        control = 0;
                        leftR.SetActive(false);
                        rightR.SetActive(false);
                    }
                }

                if (isExhausted == false && isSprinting == false && control > 0 && exhaustedStatus < 1 && stamina > 15)
                {
                    leftR.SetActive(true);
                    rightR.SetActive(true);

                    leftD.transform.localPosition -= new Vector3(add / 2, 0, 0);
                    rightD.transform.localPosition -= new Vector3((-1 * add) / 2, 0, 0);

                    if (stamina == 100)
                    {
                        leftR.SetActive(false);
                        rightR.SetActive(false);
                    }
                }
            }
        }

    }
}
