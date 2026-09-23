using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : Rotator
{
    public InputActionReference look;
    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        LookAt(mousePosition);
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
