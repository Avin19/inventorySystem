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
        ItemDisplayHide();



    }

    private void OnSellBtnCLick()
    {
        ItemDisplayHide();
    }

    private void OnBuyBtnClick()
    {

        ItemDisplayHide();

    }

    private void ItemDisplayHide()
    {
        itemDisplayRectTransfom.gameObject.SetActive(false);
    }
    public void ReceiveItemInform(ItemSO itemData)
    {
        this.itemData = itemData;
    }

}
