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
    public GameObject greenBar;

    float z = 0.5648148f;
    float y = 1.0000262f;

    public GameObject exhaustedViginette;
    public GameObject exhaustedViginetteSecond;
    bool isExhausted;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar").gameObject;
        redBar = transform.Find("Red Bar").gameObject;
        greenBar = transform.Find("Green Bar").gameObject;
        bar.transform.localScale = new Vector3(1, 0, 1);
        exhaustedViginette = transform.Find("Exhausted Viginette").gameObject;
        exhaustedViginette.transform.localScale = new Vector3(z, z, z);
    }

    // Update is called once per frame
    void Update()
    {
        stamina = sprintingScript.instance.stamina;
        isExhausted = sprintingScript.instance.isExhausted;

        bar.transform.localScale = new Vector3((stamina/100), 1, 1);

        redBar.SetActive(stamina < 15);
        greenBar.SetActive(stamina < 15 && sprintingScript.instance.isSprinting == false && isExhausted == false);

        exhaustedViginette.transform.localScale = new Vector3(-(stamina / 50)- (y), -(stamina / 50)- (y), z);
 
    }
}
