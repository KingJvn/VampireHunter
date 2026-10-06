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
    private InteractableOutline hovered;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        InteractableOutline target = null;

        if (TryGetTarget(out _, out Collider2D hit))
            target = hit.GetComponentInParent<InteractableOutline>();

        if (target == hovered) return;

        if (hovered != null) hovered.SetHighlighted(false);
        hovered = target;
        if (hovered != null) hovered.SetHighlighted(true);
    }
    public void OnInteract(InputAction.CallbackContext obj)
    {
        if (TryGetTarget(out IInteractable interactable, out _))
            interactable.Interact(this);
    }

    private bool TryGetTarget(out IInteractable interactable, out Collider2D hit)
    {
        interactable = null;
        hit = null;

        if (Mouse.current == null) return false;

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = cam.ScreenToWorldPoint(mouseScreenPos);

        hit = Physics2D.OverlapPoint(worldPos);
        if (hit == null) return false;

        interactable = hit.GetComponentInParent<IInteractable>();
        if (interactable == null) return false;

        // check if it's close to the player
        Vector2 closestPoint = hit.ClosestPoint(transform.position);
        return Vector2.Distance(transform.position, closestPoint) <= interactRange;
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

        if (hovered != null) hovered.SetHighlighted(false);
        hovered = null;
    }
}
