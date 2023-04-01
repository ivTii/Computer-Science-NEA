using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demon : MonoBehaviour
{
    public GameObject demonM;

    int random = 1;
    int countdown = 0;
    bool recentlyVanished = false;
    bool failedVanish = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 55);

        if (random == 0)
        {
            if (demonLight.instance.lightActive == false)
            {
                demonM.SetActive(true);
            }
            else countdown = 1;
        }

        if (countdown > 0)
        {
            if (demonLight.instance.lightActive == false) 
            {
                demonM.SetActive(false);
                countdown = 0;
            }
        }
    
    } 
}
     
 
