using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float moveLerp = .2f;
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

    bool canPlayerMove = true;

    Vector3 movementInput, lookInput;

    Tween runTween;
    Tween stopJumpTween;

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

    #region Move

    void HandleMove()
    {
        if (canPlayerMove == false) return;

        movementInput *= moveSpeed;
        movementInput *= runMultiplier;
        movementInput = new Vector3(movementInput.x, rb.velocity.y, movementInput.y);

        Vector3 adjustedDirection = transform.TransformDirection(movementInput);

        rb.velocity = Vector3.Lerp(rb.velocity, adjustedDirection, moveLerp);
    }

    void Run(InputAction.CallbackContext context)
    {
        if (runTween != null) runTween.Kill(true);
        runTween = DOVirtual.Float(runMultiplier, runSpeedMultiplier, .1f, x => runMultiplier = x);
    }

    void StopRun(InputAction.CallbackContext context)
    {
        if (runTween != null) runTween.Kill(true);
        runTween = DOVirtual.Float(runMultiplier, 1, .1f, x => runMultiplier = x);
    }

    #endregion

    #region Rotation

    void HandleRotation()
    {
        if (canPlayerMove == false) return;

        float mouseXPos = lookInput.x * mouseXSensitivity;
        mouseYPos -= lookInput.y * mouseYSensitivity;

        transform.Rotate(0, mouseXPos, 0);

        mouseYPos = Mathf.Clamp(mouseYPos, minYRotation, maxYRotation);
        cameraFollow.transform.localRotation = Quaternion.Euler(mouseYPos, 0, 0);
    }

    public void MoveCameraRandomly(float duration)
    {
        canPlayerMove = false;

        rb.velocity = Vector3.zero;


        Sequence moveXRandomly = DOTween.Sequence();

        Ease easeMovement = Ease.InOutSine;

        moveXRandomly
            .Join(transform.DORotate(new Vector3(0, Random.Range(-5, -20), 0), duration / 4f, RotateMode.LocalAxisAdd).SetEase(easeMovement))
            .Append(transform.DORotate(new Vector3(0, Random.Range(5, 20), 0), duration / 4f, RotateMode.LocalAxisAdd).SetEase(easeMovement))
            .Append(transform.DORotate(new Vector3(0, Random.Range(-5, -20), 0), duration / 4f, RotateMode.LocalAxisAdd).SetEase(easeMovement))
            .Append(transform.DORotate(new Vector3(0, Random.Range(5, 20), 0), duration / 8f, RotateMode.LocalAxisAdd).SetEase(easeMovement))
            .Append(transform.DORotate(new Vector3(0, Random.Range(-5, -20), 0), duration / 8f, RotateMode.LocalAxisAdd).SetEase(easeMovement));
    }

    public void StopMoveRandomly()
    {
        canPlayerMove = true;
    }

    #endregion

    #region Jump
    void Jump(InputAction.CallbackContext context)
    {
        if (canPlayerMove == false) return;

        if (IsGrounded()) rb.AddForce(Vector3.up * jumpForce);
    }

    void StopJump(InputAction.CallbackContext context)
    {
        if (rb.velocity.y > 0)
        {
            if (stopJumpTween != null) stopJumpTween.Kill(true);
            stopJumpTween = DOVirtual.Vector3(rb.velocity, new Vector3(rb.velocity.x, 0, rb.velocity.z), .2f, x => rb.velocity = x);
        }
    }

    bool IsGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 2f, groundLayermask);

        return isGrounded;
    }

    #endregion Jump

    void Interact(InputAction.CallbackContext context)
    {
        myInteractor.TryInteraction();
    }

    void OnEnable()
    {
        interact.action.performed += Interact;
        jump.action.started += Jump;
        jump.action.canceled += StopJump;
        run.action.started += Run;
        run.action.canceled += StopRun;
    }

    void OnDisable()
    {
        interact.action.performed -= Interact;
        jump.action.started -= Jump;
        jump.action.canceled -= StopJump;
        run.action.performed -= Run;
        run.action.canceled -= StopRun;
    }
}
