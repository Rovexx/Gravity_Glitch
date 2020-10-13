using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 lookPosition;
    public float xRotation = 0f;
    public float rotateSensitivity = 100f;
    public Transform player;
    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Look.performed += value => lookPosition = value.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

    private void Rotate()
    {
        float mouseX = lookPosition.x * rotateSensitivity * Time.deltaTime;
        float mouseY = lookPosition.y * rotateSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
