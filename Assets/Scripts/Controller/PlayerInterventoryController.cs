using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInterventoryController : MonoBehaviour
{
    [SerializeField] private List<ItemSO> playerInventory = new List<ItemSO>();

    [SerializeField] private GameObject pfItem;


    public void GotPlayerInventory(List<ItemSO> _playerInventory)
    {
        //Create a check for already existing items

        foreach (ItemSO item in _playerInventory)
        {

            if (!playerInventory.Contains(item)) { ItemDisplay(item); }
            else
            {
                // checkc hich item it is matching 
                for (int i = 0; i < playerInventory.Count; i++)
                {
                    if (playerInventory[i] == item)
                    {
                        playerInventory[i].quantity += item.quantity;

                    }
                }
            }

        }
    }
    private void ItemDisplay(ItemSO itemSO)
    {
        Item item = Instantiate(pfItem, gameObject.transform).GetComponent<Item>();
        item.SetSprite(itemSO.iconSprite);
        item.SetQuantityText(itemSO.quantity);
        item.ItemDetails(itemSO);
        playerInventory.Add(itemSO);


    }
}
