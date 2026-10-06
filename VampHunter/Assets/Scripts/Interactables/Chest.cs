using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public void Interact(Interactor interactor)
    {
        Debug.Log("Opened Chest");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
