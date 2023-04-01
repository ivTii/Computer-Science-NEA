using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topDownCameraScript : MonoBehaviour
{
    public float mouseSens = 100f;
    public static topDownCameraScript instance;
    

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
      

        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
