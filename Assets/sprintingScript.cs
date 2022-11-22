using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprintingScript : MonoBehaviour
{
    bool isSprinting = false;
    bool isGrounded = false;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    float m_FieldOfView;
    public float cameraDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_FieldOfView = 73.6f;
    }

    // Update is called once per frame
    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded && (Input.GetKey(KeyCode.LeftControl)==false);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isSprinting)
        {
            if (m_FieldOfView < 86.4f) // If FOV is LESS than 86.4, increase.
            {
                m_FieldOfView += 0.426f; // Takes ~0.5s to reach maximum FOV/Sprint Speed.
                if (m_FieldOfView > 86.4f) // If FOV is GREATER than 86.4, set to 86.4.
                {
                    m_FieldOfView = 86.4f;
                }
                
            }
            Camera.main.fieldOfView = m_FieldOfView;
        }
        else
        {
            if (m_FieldOfView > 73.6f)
            {
                m_FieldOfView -= 0.426f;
                if (m_FieldOfView < 73.6f)
                {
                    m_FieldOfView = 73.6f;
                }
            }
            Camera.main.fieldOfView = m_FieldOfView;
        }
    }
}
