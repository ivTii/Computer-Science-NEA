using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapScript : MonoBehaviour
{
    public GameObject map;
    public GameObject camera;
    bool mapStatus = false;
    bool cameraStatus = true;

    void Start()
    {
        map = transform.GetChild(0).gameObject;
        camera = transform.GetChild(2).gameObject;
        Debug.Log(map.name);
    }

    void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            if (mapStatus)
            {
                mapStatus = false;
                cameraStatus = true;
            }
            else
            {
                mapStatus = true;
                cameraStatus = false;
            }
        }

        map.SetActive(mapStatus);
        camera.SetActive(cameraStatus);
    }
}
