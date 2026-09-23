using UnityEngine;
using UnityEngine.InputSystem;

public class LookAhead : MonoBehaviour
{
    [Header("Tracking Targets")]
    public Transform player;

    [Header("Look Ahead Settings")]
    [Tooltip("The maximum distance the target can pull away from the player toward the mouse.")]
    public float maxMouseOffset = 4f;

    [Tooltip("How fast the pivot snaps to the mouse vector (higher = faster, lower = more weight).")]
    public float pivotSmoothSpeed = 10f;

    private void Start()
    {
        if (player != null)
        {
            transform.position = player.position;
        }
    }
    private void Update()
    {
        if(player == null) return;

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        //normalize mouse position
        float normalizedX = (mouseScreenPos.x / Screen.width) * 2f - 1f;
        float normalizedY = (mouseScreenPos.y / Screen.height) * 2f - 1f;

        Vector3 mouseDirection = new Vector3(normalizedX, normalizedY, 0f);

        if(mouseDirection.magnitude > 1f)
        {
            mouseDirection.Normalize();
        }

        //find offset position
        Vector3 targetOffset = mouseDirection * maxMouseOffset;
        Vector3 targetPosition = player.position + targetOffset;

        targetPosition.z = player.position.z;

        //move pivot point to the position
        transform.position = Vector3.Lerp(transform.position, targetPosition, pivotSmoothSpeed * Time.deltaTime);
    }
}
