using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchingScript : MonoBehaviour
{

    bool isGrounded;
    bool isCrouching;
    bool isSprinting;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    public CharacterController controller;
    public float standingHeight = 2.5f;
    public float crouchingHeight = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded && (isCrouching == false);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isCrouching = Input.GetKey(KeyCode.LeftControl) && isGrounded;

        if (isCrouching) // Using scalar to reduce over time
        {
            if (controller.height > crouchingHeight)
            {
                controller.height -= 0.084f; // Using difference over 0.25s --> 1.25f difference, 0.5s time, 60 fps => (d/t)/fps
                if (controller.height < crouchingHeight)
                {
                    controller.height = crouchingHeight;
                }
            }
        }
        else
        {
            if (controller.height < standingHeight)
            {
                controller.height += 0.084f; // Uses difference over 0.25s
                if (controller.height > standingHeight)
                {
                    controller.height = standingHeight;
                }
            }
        }
    }
}
