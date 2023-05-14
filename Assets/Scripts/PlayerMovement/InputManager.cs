using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private PlayerInputs.InputsActions input;

    private Movement movement;
    private PlayerCamera look;

    void Awake()
    {
        //New Instance of the player input class
        playerInputs = new PlayerInputs();
        input = playerInputs.Inputs;
        movement = GetComponent<Movement>();
        look = GetComponent<PlayerCamera>();

        input.Jump.performed += ctx => movement.Jump();
        input.Run.performed += ctx => movement.Run();
        input.Slide.performed += ctx => movement.Slide();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tell the play movement to move using the value from our movement action
        movement.ProcessMove(input.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(input.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
