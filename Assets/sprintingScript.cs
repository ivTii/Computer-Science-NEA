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
        m_FieldOfView = 75f;
    }

    // Update is called once per frame
    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isSprinting)
        {
            if (m_FieldOfView < 85f) // If FOV is LESS than 80, increase.
            {
                m_FieldOfView += 0.5f;
                if (m_FieldOfView > 85f) // If FOV is GREATER than 80, set to 80.
                {
                    m_FieldOfView = 85f;
                }
                
            }
            Camera.main.fieldOfView = m_FieldOfView;
        }
        else
        {
            if (m_FieldOfView > 75f)
            {
                if (m_FieldOfView < 75f)
                {
                    m_FieldOfView = 75f;
                }
                m_FieldOfView -= 0.5f;
            }
            Camera.main.fieldOfView = m_FieldOfView;
        }
    }
}
