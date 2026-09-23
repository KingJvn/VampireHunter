using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : Rotator
{
    public InputActionReference look;
    private Vector3 mouseWorldPosition;
    private void Start()
    {
        mouseWorldPosition = transform.position + transform.up; //initialize start position
    }
    private void Update()
    {
        RotateToward(mouseWorldPosition); //rotates player every frame to independently from the mouse movement. Stops player from pausing when not finished rotating
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 screenPos = context.ReadValue<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(screenPos);
    }

    private void OnEnable()
    {
        look.action.performed += OnLook;
    }
    private void OnDisable()
    {
        look.action.performed -= OnLook;
    }
}
