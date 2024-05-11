using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuySellController : MonoBehaviour
{
    [SerializeField] private Button okBtn, cancelBtn, addQuantity, subQuantity;
    [SerializeField] private TextMeshProUGUI titleTxt, quantityTxt;
    private ItemSO item;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private PlayerInventorySO playerInventorySO;
    [SerializeField] private ItemListSO shopList;

    private List<ItemSO> materialList, weaponList, comsumableList, teasureList = new List<ItemSO>();
    [SerializeField] private RectTransform playerItemDisplay;
    private int quantity = 0;
    private void OnEnable()
    {
        okBtn.onClick.AddListener(OnOkBtnClicked);
        cancelBtn.onClick.AddListener(OnCancelBtnClicked);
        addQuantity.onClick.AddListener(OnAddQuantityClicked);
        subQuantity.onClick.AddListener(OnSubQuantityClicked);

        SetupList();
    }

    private void SetupList()
    {
        foreach (ItemType itemType in shopList.Types)
        {
            if (itemType == ItemType.Material)
            {
                materialList = shopList.materialList;
            }
            else if (itemType == ItemType.Weapon)
            {
                weaponList = shopList.weaponList;
            }
            else if (itemType == ItemType.Consumable)
            {
                comsumableList = shopList.consumableList;
            }
            else if (itemType == ItemType.Treasure)
            {
                teasureList = shopList.treasureList;
            }
        }
    }

    private void OnDisable()
    {
        okBtn.onClick.RemoveListener(OnOkBtnClicked);
        cancelBtn.onClick.RemoveListener(OnCancelBtnClicked);
        addQuantity.onClick.RemoveListener(OnAddQuantityClicked);
        subQuantity.onClick.RemoveListener(OnSubQuantityClicked);
    }

    private void OnSubQuantityClicked()
    {
        quantityTxt.text = UpdateQuantity(--quantity);
    }

    private void OnAddQuantityClicked()
    {
        quantityTxt.text = UpdateQuantity(++quantity);
    }

    private void OnCancelBtnClicked()
    {
        ResetQuantity();
    }

    private void OnOkBtnClicked()
    {
        CheckingItemChangeItemQuanity(item, quantity);
        Invoke(nameof(ResetQuantity), 1f);
        ReduceTheAmountInShopList(item);
        playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().Display();
    }

    private void ReduceTheAmountInShopList(ItemSO item)
    {
        if (item.itemType == ItemType.Material)
        {
            foreach (var i in materialList)
            {
                if (i == item)
                {
                    i.quantity -= item.quantity;
                }
            }
        }
        else if (item.itemType == ItemType.Weapon)
        {
            foreach (var i in weaponList)
            {
                if (i == item)
                {
                    i.quantity -= item.quantity;
                }
            }
        }
        else if (item.itemType == ItemType.Consumable)
        {
            foreach (var i in comsumableList)
            {
                if (i == item)
                {
                    i.quantity -= item.quantity;
                }
            }

        }
        else if (item.itemType == ItemType.Treasure)
        {
            foreach (var i in teasureList)
            {
                if (i == item)
                {
                    i.quantity -= item.quantity;
                }
            }

        }


    }

    public void SetItem(ItemSO item)
    {
        this.item = item;

    }
    private string UpdateQuantity(int quantity)
    {
        if (quantity >= 0)
        {
            titleTxt.text = "Buy";
        }
        else
        {
            titleTxt.text = "Sell";
        }
        return quantity.ToString();
    }
    private void CheckingItemChangeItemQuanity(ItemSO item, int quantity)
    {
        if (playerInventorySO.Inventory.Contains(item))
        {
            foreach (ItemSO i in playerInventorySO.Inventory)
            {
                if (i == item)
                {
                    if (quantity > 0 || playerStatus.coin > i.buyingPrice)
                    {
                        i.quantity += quantity;
                        playerStatus.coin -= i.buyingPrice;
                        playerStatus.playerItemWeight += i.weight;

                    }
                    else
                    {
                        if (i.quantity > quantity)
                        {
                            i.quantity += quantity;
                            playerStatus.coin += i.sellingPrice;
                            playerStatus.playerItemWeight -= i.weight;
                        }
                        else
                        {
                            titleTxt.text = " You Dont Have that much quanity";
                        }
                    }
                }

            }
        }
        else
        {
            playerInventorySO.Inventory.Add(item);
        }

    }
    private void ResetQuantity()
    {
        this.gameObject.SetActive(false);
        quantity = 0;
    }

}