using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float runSpeedMultiplier = 2f;
    [SerializeField] float jumpForce = 300f;
    [SerializeField] LayerMask groundLayermask;

    [Space(20)]
    [Header("Look")]
    [SerializeField] float mouseXSensitivity = .2f;
    [SerializeField] float mouseYSensitivity = .2f;
    [SerializeField] float maxYRotation = 50f;
    [SerializeField] float minYRotation = -90f;

    [Space(20)]
    [Header("Interact")]
    public PlayerInteractor myInteractor;

    [Space(20)]
    [Header("Ref")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform cameraFollow;
    [SerializeField] InputActionReference movement, look, interact, jump, run;

    float runMultiplier = 1f;
    float mouseYPos;
    bool canJump = true;

    Vector3 movementInput, lookInput;

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();
        lookInput = look.action.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        HandleMove();
        HandleRotation();
    }

    void HandleMove()
    {
        movementInput *= moveSpeed;
        movementInput *= runMultiplier;
        movementInput = new Vector3(movementInput.x, rb.velocity.y, movementInput.y);

        Vector3 adjustedDirection = transform.TransformDirection(movementInput);

        rb.velocity = adjustedDirection;
    }

    void HandleRotation()
    {
        float mouseXPos = lookInput.x * mouseXSensitivity;
        mouseYPos -= lookInput.y * mouseYSensitivity;

        transform.Rotate(0, mouseXPos, 0);

        mouseYPos = Mathf.Clamp(mouseYPos, minYRotation, maxYRotation);
        cameraFollow.transform.localRotation = Quaternion.Euler(mouseYPos, 0, 0);
    }

    void Interact(InputAction.CallbackContext context)
    {
        myInteractor.TryInteraction();
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }


    bool IsGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.25f, Vector3.down, 1f, groundLayermask);

        return isGrounded;
    }


    void Run(InputAction.CallbackContext context)
    {
        runMultiplier = runSpeedMultiplier;
    }

    void StopRun(InputAction.CallbackContext context)
    {
        runMultiplier = 1;
    }

    void OnEnable()
    {
        interact.action.performed += Interact;
        jump.action.performed += Jump;
        run.action.started += Run;
        run.action.canceled += StopRun;
    }

    void OnDisable()
    {
        interact.action.performed -= Interact;
        jump.action.performed -= Jump;
        run.action.performed -= Run;
        run.action.canceled -= StopRun;
    }
}
