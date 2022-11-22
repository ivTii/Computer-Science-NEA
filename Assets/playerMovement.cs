using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float baseSpeed = 8f; // Adjustable default speed
    private float currentSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;
    bool isCrouching;
    bool mapStatus = false;

    // Update is called on start-up
    void Start()
    {
        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Creates an invisible Sphere below the player. When colliding with groundMask, becomes true.
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded && (isCrouching == false); // Checks for LSHIFT key down, TRUE when pressed
        isCrouching = Input.GetKey(KeyCode.LeftControl) && isGrounded;

        if (isGrounded && velocity.y < 0) // Prevents gravity from increasing rapidly
        {
            velocity.y = -6f;
        }

        if (isSprinting) // While sprinting, speed = 1.5x
        {
            if (currentSpeed < 12f)
            {
                currentSpeed += 0.135f; // Takes 0.5s to reach maximum speed.
                if (currentSpeed > 12f)
                {
                    currentSpeed = 12f;
                }
            }
        } 
        else
        {
            if (currentSpeed > 8f)
            {
                currentSpeed -= 0.135f;
                if (currentSpeed < 8f)
                {
                    currentSpeed = 8f;
                }
            }
        }
        
        if (isCrouching)
        {
            if (currentSpeed > 4f)
            {
                currentSpeed -= 0.135f; // Takes 0.5s to reach crouching speed.
                if (currentSpeed < 4f)
                {
                    currentSpeed = 4f; // Sets speed back to 4f as a limit.
                }
            }
        }
        else
        {
            if (currentSpeed < 8f)
            {
                currentSpeed += 0.135f;
                if (currentSpeed > 8f)
                {
                    currentSpeed = 8f;
                }
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded) // While on ground, jump is available
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Map"))
        {
            if (mapStatus)
            {
                mapStatus = false;
                baseSpeed = baseSpeed / 0.4f;
            }
            else
            {
                mapStatus = true;
                baseSpeed = baseSpeed * 0.4f;
            }
        }

        velocity.y += gravity * Time.deltaTime; // Gravity is constant

        controller.Move(velocity * Time.deltaTime); // Velocity is constant every frame while key is pressed

        Vector3 move = transform.right * x + transform.forward * z; // Basic movement for the player, x-axis being horizontal, z-axis being vertical

        controller.Move(move * currentSpeed * Time.deltaTime); // Movement from 36 * current speed * time.

    }

}
