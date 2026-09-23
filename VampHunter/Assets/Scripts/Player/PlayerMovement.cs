using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float sprintSpeed = 3.5f;
    [SerializeField] private float currentSpeed = 0;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public InputActionReference move;
    public InputActionReference sprint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentSpeed = walkSpeed;
    }
    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * currentSpeed, moveDirection.y * currentSpeed);
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton())
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
        
    }
    private void OnEnable()
    {
        move.action.Enable();
        sprint.action.performed += OnSprint;
        sprint.action.canceled += OnSprint;
    }
    private void OnDisable()
    {
        move.action.Disable();
        sprint.action.performed -= OnSprint;
        sprint.action.canceled -= OnSprint;
    }
}
