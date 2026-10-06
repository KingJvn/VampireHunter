using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact(Interactor interactor);
}
public class Interactor : MonoBehaviour
{
    public InputActionReference interact;
    [SerializeField] private float interactRange = 1.5f;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnInteract(InputAction.CallbackContext obj)
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = cam.ScreenToWorldPoint(mouseScreenPos);

        Collider2D hit = Physics2D.OverlapPoint(worldPos);
        if (hit == null) return;

        IInteractable interactable = hit.GetComponentInParent<IInteractable>();
        if (interactable == null) return;

        //check if its close to player
        Vector2 closestPoint = hit.ClosestPoint(transform.position);
        if (Vector2.Distance(transform.position, closestPoint) > interactRange) return;

        interactable.Interact(this);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    private void OnEnable()
    {
        interact.action.started += OnInteract;
    }

    private void OnDisable()
    {
        interact.action.started -= OnInteract;
    }
}
