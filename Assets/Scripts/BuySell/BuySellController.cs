using System;
using UnityEngine;

public class BuySellController
{
    private BuyCellView buyCellView;


    private int quantity = 0;
    private PlayerStatus playerStatus;
    private ItemListSO shopList;

    public BuySellController(PlayerStatus playerStatus, ItemListSO shopList)
    {
        this.playerStatus = playerStatus;
        this.shopList = shopList;
    }

    public BuySellController(BuyCellView buyCellView)
    {
        this.buyCellView = buyCellView;
        buyCellView.OkButton.onClick.AddListener(OnOkButtonClick);
        buyCellView.AddQuantityButton.onClick.AddListener(OnAddQuantityButtonClick);
        buyCellView.RemoveQuantityButton.onClick.AddListener(OnRemoveQuantityButtonClick);
        buyCellView.CancelButton.onClick.AddListener(OnCancelButtonClick);
    }
    ~BuySellController()
    {
        buyCellView.OkButton.onClick.RemoveListener(OnOkButtonClick);
        buyCellView.AddQuantityButton.onClick.RemoveListener(OnAddQuantityButtonClick);
        buyCellView.RemoveQuantityButton.onClick.RemoveListener(OnRemoveQuantityButtonClick);
        buyCellView.CancelButton.onClick.RemoveListener(OnCancelButtonClick);
    }

    private void OnCancelButtonClick()
    {

    }

    private void OnRemoveQuantityButtonClick()
    {
        quantity--;
        buyCellView.QuantityText.text = quantity.ToString();
        Debug.Log(quantity);
    }

    private void OnAddQuantityButtonClick()
    {
        quantity++;
        buyCellView.QuantityText.text = quantity.ToString();
        Debug.Log(quantity);
    }

    private void OnOkButtonClick()
    {


    }
}

