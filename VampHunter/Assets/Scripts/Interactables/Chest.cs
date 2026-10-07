using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public List<ItemSO> lootContents = new List<ItemSO>();
    public void Interact(Interactor interactor)
    {
        Debug.Log("Opened Chest");
        interactor.inventory.lootContainer.SetActive(true); //displays window
        lootContents = GetComponent<LootTable>().CreateLootBag();
        
    }
}
