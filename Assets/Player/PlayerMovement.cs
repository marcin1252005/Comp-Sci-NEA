using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    public PlayerControls playerControls;
    private InputAction move;
    private InputAction look;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 lookDirection = Vector2.zero;
    
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera cam;

    [Header("Configurations")]
    public float walkSpeed;
    public float sprintSpeed;

    public void Awake()
    {
        playerControls = new PlayerControls();
    }

    public void OnEnable()
    {
        move = playerControls.Player.Move;
        look = playerControls.Player.Look;
        move.Enable();
        look.Enable();
    }

    public void OnDisable()
    {
        move.Disable();
        look.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f)
        {
            moveDirection = move.ReadValue<Vector2>();
            lookDirection = look.ReadValue<Vector2>();

            float mouseX = lookDirection.x;
            float mouseY = lookDirection.y;

            transform.Rotate(Vector3.up * mouseX);
            float verticalRotation = -mouseY;
            head.Rotate(Vector3.right * verticalRotation);
        }


    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveDirection.x * walkSpeed, 0, moveDirection.y * walkSpeed);
        rb.velocity = transform.TransformDirection(movement);
    }
}
