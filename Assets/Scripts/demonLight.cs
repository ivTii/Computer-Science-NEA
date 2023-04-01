using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonLight : MonoBehaviour
{
    public GameObject light;
    public bool lightActive;

    int random = 1;
    public int countdown;

    public static demonLight instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 38);

        if (random == 0)
        {
            countdown = 30;
        }

        if (countdown > 0)
        {
            countdown--;
            random = 999;
            light.SetActive(true);
            lightActive = true;
        }
        else
        {
            light.SetActive(false);
            lightActive = false;
        }
        
    }
}
