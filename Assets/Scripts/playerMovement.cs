using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject player;

    public float baseSpeed = 5f; // Adjustable default speed
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

    float stamina;
    float exhaustedStatus = 0f;
    bool isExhausted;

    public static playerMovement instance;

    // Update is called on start-up
    void Start()
    {
        currentSpeed = baseSpeed;
        instance = this;
        stamina = sprintingScript.instance.stamina;
        Debug.Log(transform.localPosition.x);
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Creates an invisible Sphere below the player. When colliding with groundMask, becomes true.
        isSprinting = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded && (isCrouching == false) && exhaustedStatus == 0 && mapStatus == false; // Checks for LSHIFT key down, TRUE when pressed
        isCrouching = Input.GetKey(KeyCode.LeftControl) && isGrounded && mapStatus == false;
        isExhausted = stamina <= 0f;

        if (isGrounded && velocity.y < 0) velocity.y = -6f; // Prevents gravity from increasing rapidly

        if (isExhausted && exhaustedStatus == 0f) exhaustedStatus = 5f; // Grants the player exhausted status

        if (exhaustedStatus > 0f & isSprinting == false) // Exhausted recovery for 6s
        {
            exhaustedStatus -= 0.0166f;
            if (exhaustedStatus < 4f) // Stamina recovery while recoving from exhausted
            {
                stamina += 0.104f; 
            }
        } 

        if (exhaustedStatus <= 0f) // Prevents exhaustedStatus being less than 0
        {
            exhaustedStatus = 0f;
        }
   
    
        if (isSprinting == false && exhaustedStatus == 0)
        {
            stamina += 0.104f; // Takes 16s to reach 100 stamina.

            if (stamina > 100) // Prevents stamina going over 100
            {
                stamina = 100;
            }
        }

        if (stamina < 0) // Prevents stamina being less than 0. isExhausted will still trigger upon falling under (extra frame)
        {
            stamina = 0;
        }
        

        if (isSprinting && stamina > 0 && isExhausted == false) // While sprinting, speed = 1.5x
        {
            stamina -= 0.208f; // Takes 8s to reach 0 stamina.
                if (currentSpeed < 7.5f)
                {
                    currentSpeed += 0.083f; // Takes 0.5s to reach maximum speed.
                    if (currentSpeed > 7.5f)
                    {
                        currentSpeed = 7.5f;
                    }

                }
            
        } 
        else
        {
            if (currentSpeed > 5f)
            {
                currentSpeed -= 0.083f;
                if (currentSpeed < 5f)
                {
                    currentSpeed = 5f;
                }
                exhaustedStatus += 0.0332f;
            }
        }
        
        if (isCrouching) // While crouching, speed = 0.5x
        {
            if (currentSpeed > 2.5f)
            {
                currentSpeed -= 0.083f; // Takes 0.5s to reach crouching speed.
                if (currentSpeed < 2.5f)
                {
                    currentSpeed = 2.5f; // Sets speed back to 2.5f as a limit.
                }
            }
        }
        else
        {
            if (currentSpeed < 5f)
            {
                currentSpeed += 0.083f;
                if (currentSpeed > 5f)
                {
                    currentSpeed = 5f;
                }
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded) // While on ground, jump is available
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Map")) // Check for mapStatus, decreasing speed if necessary
        {
            if (mapStatus)
            {
                mapStatus = false;
                currentSpeed = baseSpeed / 0.4f;
            }
            else
            {
                mapStatus = true;
                currentSpeed = baseSpeed * 0.4f;
            }
        }

        velocity.y += gravity * Time.deltaTime; // Gravity is constant

        controller.Move(velocity * Time.deltaTime); // Velocity is constant every frame while key is pressed

        Vector3 move = transform.right * x + transform.forward * z; // Basic movement for the player, x-axis being horizontal, z-axis being vertical

        controller.Move(move * currentSpeed * Time.deltaTime); // Movement from 36 * current speed * time.

    }

}
