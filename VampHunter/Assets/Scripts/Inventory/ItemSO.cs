using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int maxStackSize;
    public GameObject itemPrefab;
    public int dropChance;

    public ItemSO(string lootName, int dropChance)
    {
        this.itemName = lootName;
        this.dropChance = dropChance;
    }
}
