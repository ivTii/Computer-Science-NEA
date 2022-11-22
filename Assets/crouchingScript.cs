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
    public float standingHeight = 2f;
    public float crouchingHeight = 1.5f;

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

        if (isCrouching)
        {
            controller.height = crouchingHeight;
        }
        else
        {
            controller.height = standingHeight;
        }
    }
}
