using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //https://youtu.be/PUKYv-afRnc?si=gg58WUN8HzKdj__i
    //Referenced this tutorial

    public bool hovering;
    private ItemSO heldItem;
    private int itemAmount;
    private Image iconImage;
    private TextMeshProUGUI amountTxt;
    private void Awake()
    {
        iconImage = transform.GetChild(0).GetComponent<Image>();
        amountTxt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    //since these variables are private I need to have getter functions 
    public ItemSO GetItem()
    {
        return heldItem;
    }
    public int GetAmount()
    {
        return itemAmount;
    }

    //function that allows me to set items in the slots in the inventory script
    public void SetItem(ItemSO item, int amount = 1)
    {
        heldItem = item;
        itemAmount = amount;

        UpdateSlot();
    }

    //function used to update values for the slot 
    public void UpdateSlot()
    {
        if(heldItem != null)
        {
            iconImage.enabled = true;
            iconImage.sprite = heldItem.icon;
            amountTxt.text = itemAmount.ToString();
        }
        else
        {
            iconImage.enabled = false;
            amountTxt.text = "";
        }
    }

    public int AddAmount(int amountToAdd)
    {
        itemAmount += amountToAdd;
        UpdateSlot();
        return itemAmount;
    }

    public int RemoveAmount(int amountToRemove)
    {
        itemAmount -= amountToRemove;
        if (itemAmount <= 0)
        {
            ClearSlot();
        }
        else
        {
            UpdateSlot();
        }

        return itemAmount;
    }

    public void ClearSlot()
    {
        heldItem = null;
        itemAmount = 0;
        UpdateSlot();
    }

    public bool HasItem()
    {
        return heldItem != null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
    }
}
