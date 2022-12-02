using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprintingScript : MonoBehaviour
{
    public bool isSprinting = false;
    bool isGrounded = false;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    float m_FieldOfView;
    public float cameraDelay = 1f;

    public float stamina = 100f;
    public float exhaustedStatus = 0f;
    public bool isExhausted;

    public static sprintingScript instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_FieldOfView = 73.6f;
    }

    // Update is called once per frame
    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded && (Input.GetKey(KeyCode.LeftControl)==false) && exhaustedStatus == 0;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isExhausted = stamina <= 0f;

        if (isExhausted && exhaustedStatus == 0f)
        {
            exhaustedStatus = 300f;
        }

        if (exhaustedStatus > 0f & isSprinting == false)
        {
            exhaustedStatus -= 1f;
        }


        if (isSprinting == false && exhaustedStatus == 0)
        {
            stamina += 0.104f; // Takes 16s to reach 100 stamina.

            if (stamina > 100)
            {
                stamina = 100;
            }
            if (stamina < 0)
            {
                stamina = 0;
            }
        }

        if (isSprinting && stamina > 0 && isExhausted == false)
        {
            stamina -= 0.208f;
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
                exhaustedStatus += 2f;
            }
            Camera.main.fieldOfView = m_FieldOfView;
        }
    }
}
