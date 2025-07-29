using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Components
    [SerializeField] private Rigidbody Rb;

    // Movement variables
    [Header("Movement")]
    [SerializeField] private float WalkSpeed = 600;
    [SerializeField] private float SprintSpeed = 1200;

    private bool _isSprinting;

    // Rotation variables
    [Header("Rotation")]
    [SerializeField] private float MouseSensitivity = 50;
    
    // Other variables
    private InputSystemActions _actions;

    private Vector2 moveInput;
    private float mouseX;
    
    // Functions
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _actions = new InputSystemActions();

        _actions.Player.Move.performed += ctx => { moveInput = ctx.ReadValue<Vector2>(); };
        _actions.Player.Move.canceled += _ => { moveInput = Vector2.zero; };

        _actions.Player.Look.performed += ctx => { mouseX = ctx.ReadValue<Vector2>().x; };
        _actions.Player.Look.canceled += _ => { mouseX = 0; };

        _actions.Player.Sprint.performed += _ => _isSprinting = true;
        _actions.Player.Sprint.canceled += _ => _isSprinting = false;
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        float speed = _isSprinting ? SprintSpeed : WalkSpeed;

        Rb.linearVelocity = moveVector * (speed * Time.deltaTime);
    }

    private void Look()
    {
        transform.Rotate(Vector3.up * (mouseX * MouseSensitivity * Time.deltaTime));
    }
}
