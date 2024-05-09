using System;
using System.Collections;
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
    private int quantity = 0;
    private void OnEnable()
    {
        okBtn.onClick.AddListener(OnOkBtnClicked);
        cancelBtn.onClick.AddListener(OnCancelBtnClicked);
        addQuantity.onClick.AddListener(OnAddQuantityClicked);
        subQuantity.onClick.AddListener(OnSubQuantityClicked);
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
        UpdateQuantity(quantity--);
    }

    private void OnAddQuantityClicked()
    {
        UpdateQuantity(quantity++);
    }

    private void OnCancelBtnClicked()
    {
        this.gameObject.SetActive(false);
    }

    private void OnOkBtnClicked()
    {
        CheckingItemChangeItemQuanity(item, quantity);

    }

    public void SetItem(ItemSO item)
    {
        this.item = item;



    }
    private string UpdateQuantity(int quantity)
    {
        if (quantity > 0)
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
        foreach (ItemSO i in playerInventorySO.Inventory)
        {
            if (i == item)
            {
                if (quantity > 0 || playerStatus.coin > i.buyingPrice)
                {
                    i.quantity += quantity;
                    playerStatus.coin -= i.buyingPrice;
                    playerStatus.maxplayerWeight += i.weight;

                }
                else
                {
                    if (i.quantity > quantity)
                    {
                        i.quantity -= quantity;
                        playerStatus.coin += i.sellingPrice;
                        playerStatus.maxplayerWeight -= i.weight;
                    }
                    else
                    {
                        titleTxt.text = " You Dont Have that much quanity";
                    }
                }
            }

        }


    }

}
