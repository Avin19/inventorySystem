using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterventoryController : MonoBehaviour
{
    [SerializeField] private List<ItemSO> playerInventory = new List<ItemSO>();
    [SerializeField] private GameObject pfItem;


    public void GotPlayerInventory(List<ItemSO> playerInventory)
    {
        //Create a check for already existing items

        foreach (ItemSO item in playerInventory)
        {
            ItemDisplay(item);

        }
    }
    private void ItemDisplay(ItemSO itemSO)
    {
        Item item = Instantiate(pfItem, gameObject.transform).GetComponent<Item>();
        item.SetSprite(itemSO.iconSprite);
        item.SetQuantityText(itemSO.quantity);
        item.ItemDetails(itemSO);

    }
}
