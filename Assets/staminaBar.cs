using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    [SerializeField]
    private float stamina;
    public GameObject bar;
    public GameObject redBar;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar").gameObject;
        redBar = transform.Find("Red Bar").gameObject;
        bar.transform.localScale = new Vector3(1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        stamina = sprintingScript.instance.stamina;

 
            bar.transform.localScale = new Vector3((stamina/100), 1, 1);

        if (stamina < 25)
        {
            redBar.SetActive(true);
        }
        else
        {
            redBar.SetActive(false);
        }
    }
}
