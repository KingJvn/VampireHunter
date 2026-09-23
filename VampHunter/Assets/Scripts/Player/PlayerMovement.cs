using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public InputActionReference move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    private void OnEnable()
    {
        move.action.Enable();
    }
    private void OnDisable()
    {
        move.action.Disable();
    }
}
