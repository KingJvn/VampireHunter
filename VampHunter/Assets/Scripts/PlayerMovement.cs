using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private PlayerHealth playerHealth; //for not letting player move when dead
    private Rigidbody2D rb;
    private Vector2 movementInput;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        if (playerHealth.isDead) return;
        movementInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * speed;
    }
}
