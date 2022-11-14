using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float baseSpeed = 8f; // Adjustable default speed
    private float speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;
    bool mapStatus = false;

    // Update is called on start-up
    void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Creates an invisible Sphere below the player. When colliding with groundMask, becomes true.
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded; // Checks for LSHIFT key down, TRUE when pressed

        if (isGrounded && velocity.y < 0) // Prevents gravity from increasing rapidly
        {
            velocity.y = -6f;
        }

        if (isSprinting) // While sprinting, speed = 1.5x
        {
            speed = baseSpeed * 1.5f;
        }
        else
        {
            speed = baseSpeed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // Basic movement for the player, x-axis being horizontal, z-axis being vertical

        controller.Move(move * speed * Time.deltaTime); // Movement from 36 * current speed * time.

        if (Input.GetButtonDown("Jump") && isGrounded) // While on ground, jump is available
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime; // Gravity is constant

        controller.Move(velocity * Time.deltaTime); // Velocity is constant every frame while key is pressed

        if (Input.GetButtonDown("Map"))
        {
            if (mapStatus)
            {
                mapStatus = false;
            }
            else
            { 
                mapStatus = true;
            }
        }

        if (mapStatus)
        {
            speed = 0f;
        } 
        else
        {
            speed = baseSpeed;
        }


    }

}
