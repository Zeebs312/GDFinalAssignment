using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    [Header("Movement Parameter")]
    private float speed = 10f;

    [Header("Jumping Parameters")]
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    private bool doubleJump = false;

    [Header("Conditional Parameters")]
    private bool isGrounded;
    public bool running = false;

    [Header("Sliding Parameters")]
    public bool sliding = false;
    private float slideTimer = 1;
    private bool lerpSlide = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.height = 3;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpSlide)
        {
            slideTimer += Time.deltaTime;
            float p = slideTimer / 1;
            p *= p;
            if (sliding)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 3, p);

            if (p > 1)
            {
                lerpSlide = false;
                slideTimer = 0f;
            }
        }
    }

    //Receives inputs from Input Manager & apply to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
        playerVelocity.y += gravity * Time.deltaTime;

        //Stops player from sliding 
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            doubleJump = true;
        }
        else if (doubleJump)
        {
            doubleJump = false;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Run()
    {
        running = !running;
        if (running)
            speed = 15f;
        else
            speed = 10f;
    }

    public void Slide()
    {
        sliding = !sliding;
        if (isGrounded && sliding)
        {
            speed = 15f;
            slideTimer = 0f;
            lerpSlide = true;
        }
        else
        {
            speed = 10f;
        }
    }
}