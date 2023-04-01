using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonLight : MonoBehaviour
{
    public GameObject light;

    int random = 1;
    int countdown;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else light.SetActive(false);
    }
}
