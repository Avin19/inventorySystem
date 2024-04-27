using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button buyBtn, sellBtn, gatherBtn, increaseQuantityBtn, decreaseQuantitybtn, confirmBtn, cancelBtn;
    [SerializeField] private RectTransform itemDisplayRectTransfom;
    [SerializeField] private RectTransform playerItemDisplay;
    [SerializeField] private RectTransform shopItemDisplay;
    [SerializeField] private List<ItemSO> playerInventory = new List<ItemSO>();
    [SerializeField] private ItemSO itemData;
    [SerializeField] private RectTransform buysellPanel;


    private void Awake()
    {
        buyBtn.onClick.AddListener(OnBuyBtnClick);
        sellBtn.onClick.AddListener(OnSellBtnCLick);
        gatherBtn.onClick.AddListener(OnGatherBtnClick);
    }

    private void OnGatherBtnClick()
    {
        BuySellPanelControl(false);
        ItemDisplayHide();
        if (!playerItemDisplay.gameObject.activeSelf)
        {
            itemDisplayRectTransfom.position = playerItemDisplay.position;
            return;
        }
        itemDisplayRectTransfom.position = shopItemDisplay.position;




    }

    private void OnSellBtnCLick()
    {
        BuySellPanelControl(true);
        itemDisplayRectTransfom.position = shopItemDisplay.position;
        playerItemDisplay.gameObject.SetActive(true);
        shopItemDisplay.gameObject.SetActive(!playerItemDisplay.gameObject.activeSelf);
    }

    private void OnBuyBtnClick()
    {
        BuySellPanelControl(true);
        itemDisplayRectTransfom.position = shopItemDisplay.position;
        playerItemDisplay.gameObject.SetActive(true);
        shopItemDisplay.gameObject.SetActive(!playerItemDisplay.gameObject.activeSelf);

    }

    private void ItemDisplayHide()
    {
        itemDisplayRectTransfom.gameObject.SetActive(false);
    }
    public void ReceiveItemInform(ItemSO itemData)
    {
        this.itemData = itemData;
    }
    private void BuySellPanelControl(bool check = true)
    {
        buysellPanel.gameObject.SetActive(check);
    }
    private void BuySellPanelUpdate()
    {
        // increase btn , decress btn 

    }
    public void PLayerInventoryDisplay()
    {
        playerItemDisplay.gameObject.SetActive(false);
    }

}
