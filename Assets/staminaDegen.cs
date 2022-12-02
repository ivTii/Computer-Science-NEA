using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaDegen : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

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
        left = transform.Find("Left").gameObject;
        right = transform.Find("Right").gameObject;
        left.SetActive(true); 
        right.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        stamina = sprintingScript.instance.stamina;
        isSprinting = sprintingScript.instance.isSprinting;
        isExhausted = sprintingScript.instance.isExhausted;
        exhaustedStatus = sprintingScript.instance.exhaustedStatus;

        if (stamina < 15 || stamina == 100) degenState = false;
        else degenState = true;

        if (isSprinting && stamina > 15) control++;

        if (degenState && isSprinting)
        {
            left.SetActive(true);
            left.transform.localPosition += new Vector3(add, 0, 0);
            right.SetActive(true);
            right.transform.localPosition += new Vector3((-1*add), 0, 0);

        } 
        else
        {
            left.SetActive(false);
            right.SetActive(false);

            if (isExhausted == false && isSprinting == false && exhaustedStatus < 1 && stamina > 15)
            {
                control-= 0.5; // Lose control while regenerating
                if (control < 0)
                {
                    control = 0;    
                }
            }

            if (isExhausted == false && isSprinting == false && control > 0 && exhaustedStatus < 1 && stamina > 15)
            {
                left.transform.localPosition -= new Vector3(add/2, 0, 0);
                right.transform.localPosition -= new Vector3((-1 * add)/2, 0, 0);
            }
        }
                
    }
}
