using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public List<ItemSO> lootContents = new List<ItemSO>();
    private bool opened = false;
    public bool CanInteract => !opened;
    public void Interact(Interactor interactor)
    {
        if (opened) return;
        opened = true;

        Debug.Log("Opened Chest");
        interactor.inventory.lootContainer.SetActive(true); //displays window
        lootContents = GetComponent<LootTable>().CreateLootBag();
        
    }
}
