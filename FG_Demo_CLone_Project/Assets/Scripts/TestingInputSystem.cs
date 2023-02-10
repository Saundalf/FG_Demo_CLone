using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody rb;
    private Coroutine coroutine;
    private InputActions playerInput;
    private bool IsOnGround;

    public Collider collider;
    public float movementSpeed = 5f;
    public float jumpValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new InputActions();
        playerInput.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * -movementSpeed, ForceMode.Force);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            StartCoroutine(DelayJumpCor());
        }
    }

    IEnumerator DelayJumpCor()
    {
        playerInput.Player.Jump.Disable();
        yield return new WaitUntil(() => IsOnGround);
        playerInput.Player.Jump.Enable();
    }

    private void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            IsOnGround = true;
        }
    }

    private void OnCollisionExit(Collision Other)
    {
        if (Other.gameObject.tag == "Ground")
        {
            IsOnGround = false;
        }
    }


    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

}
