using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public PlayerInputActions inputActions;
    public Vector2 movementVector;
    public float movementSpeed = 5f;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Move.performed += value => movementVector = value.ReadValue<Vector2>();
        inputActions.Player.RotateE.performed += RotateE_performed;
        inputActions.Player.RotateQ.performed += RotateQ_performed;
    }

    private void RotateQ_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        transform.Rotate(-90f,0f,0f);
    }

    private void RotateE_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        transform.Rotate(90f,0f,0f);
    }

    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

    void FixedUpdate()
    {
        float horizontal = movementVector.x;
        float vertical = movementVector.y;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Move(direction);
    }

    private void Move(Vector3 moveDirection)
    {
        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 relativeDirection = playerCamera.transform.right * moveDirection.x + playerCamera.transform.forward * moveDirection.z;
            Vector3 movement = relativeDirection * movementSpeed * Time.fixedDeltaTime;

            _rigidbody.MovePosition(transform.position + movement);
        }
    }
}
