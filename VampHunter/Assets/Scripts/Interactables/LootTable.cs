using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LootTable : MonoBehaviour
{
    public List<ItemSO> lootList = new List<ItemSO>();
    public int lootAmount = 2;
    ItemSO GetLoot()
    {
        int randomNumber = Random.Range(1, 101); //1-100
        List<ItemSO> possibleItems = new List<ItemSO>();
        foreach(ItemSO item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0) //if more than 1 item can be added
        {
            ItemSO droppedItem = possibleItems[Random.Range(0, possibleItems.Count)]; //randomly pick item 
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

    public List<ItemSO> CreateLootBag()
    {
        List<ItemSO> lootContents = new List<ItemSO>();

        for (int i = 0; i < lootAmount; i++)
        {
            ItemSO item = GetLoot();
            if(item != null)
            {
                lootContents.Add(item);
            }
        }
        return lootContents;
    }
}
