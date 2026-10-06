using UnityEngine;

public class InteractableOutline : MonoBehaviour
{
    [SerializeField] private GameObject outlineObject;

    private void Awake()
    {
        if (outlineObject != null) outlineObject.SetActive(false);
    }

    public void SetHighlighted(bool on)
    {
        if (outlineObject != null) outlineObject.SetActive(on);
    }

    private void OnDisable() => SetHighlighted(false);
}
