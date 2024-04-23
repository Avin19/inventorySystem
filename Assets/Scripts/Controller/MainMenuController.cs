using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button buyBtn, sellBtn, gatherBtn;
    [SerializeField] private RectTransform itemDisplayRectTransfom;
    [SerializeField] private List<ItemSO> playerInventory = new List<ItemSO>();
    [SerializeField] private ItemListSO itemListSO;

    private void Awake()
    {
        buyBtn.onClick.AddListener(OnBuyBtnClick);
        sellBtn.onClick.AddListener(OnSellBtnCLick);
        gatherBtn.onClick.AddListener(OnGatherBtnClick);
    }

    private void OnGatherBtnClick()
    {
        ItemDisplayHide();
        foreach (ItemSO item in itemListSO.weaponList)
        {
            Debug.Log(item.itemDescription);
        }


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
}
