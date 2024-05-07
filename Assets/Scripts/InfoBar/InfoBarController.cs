
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBarController
{
    private InfoBarView infoBarView;
    public InfoBarController(InfoBarView infoBarView)
    {
        this.infoBarView = infoBarView;
        infoBarView.PlayerInventoryButton.onClick.AddListener(OnPlayerInventoryButtonClick);
        infoBarView.ShopButton.onClick.AddListener(OnShopButtonClick);
    }
    ~InfoBarController()
    {
        infoBarView.PlayerInventoryButton.onClick.RemoveListener(OnPlayerInventoryButtonClick);
        infoBarView.ShopButton.onClick.RemoveListener(OnShopButtonClick);
    }

    private void OnShopButtonClick()
    {

    }

    private void OnPlayerInventoryButtonClick()
    {

    }
}
