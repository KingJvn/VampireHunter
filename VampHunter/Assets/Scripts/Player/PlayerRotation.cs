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
        Vector2 screenPos = look.action.ReadValue<Vector2>();

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(screenPos);
        mouseWorldPosition.z = transform.position.z;

        RotateToward(mouseWorldPosition); //rotates player every frame to independently from the mouse movement. Stops player from pausing when not finished rotating
    }

    private void OnEnable()
    {
        look.action.Enable();
    }
    private void OnDisable()
    {
        look.action.Disable();
    }
}
