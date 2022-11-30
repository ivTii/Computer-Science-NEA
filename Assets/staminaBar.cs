using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    [SerializeField]
    private float stamina;
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.GetChild(0).gameObject;
        bar.transform.localScale = new Vector3(1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        stamina = sprintingScript.instance.stamina;
        if (stamina != 0)
        {
            bar.transform.localScale = new Vector3((stamina/100), 1, 1);
        }
    }
}
