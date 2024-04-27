

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
    [SerializeField] private ItemListSO playerInventorySOList;
    [SerializeField] private ItemSO itemData;
    [SerializeField] private ItemListSO shopItemList;
    [SerializeField] private RectTransform buysellPanel;
    [SerializeField] private InfoBarController infoBarController;
    private int coin = 0;


    private void Awake()
    {
        buyBtn.onClick.AddListener(OnBuyBtnClick);
        sellBtn.onClick.AddListener(OnSellBtnCLick);
        gatherBtn.onClick.AddListener(OnGatherBtnClick);
    }
    public void ItemDisplayLocation()
    {
        if (!playerItemDisplay.gameObject.activeSelf)
        {
            itemDisplayRectTransfom.position = playerItemDisplay.position;
            return;
        }
        itemDisplayRectTransfom.position = shopItemDisplay.position;
    }

    private void OnGatherBtnClick()
    {
        ItemDisplayLocation();
        BuySellPanelControl(false);
        ItemDisplayHide();


        coin += Random.Range(0, 50000);
        infoBarController.UpdateCoinValue(coin);

        // player material Gather 
        PlayerMaterialGather();

    }

    private void PlayerMaterialGather()
    {
        ItemType itemlist = ItemType.Material;
        for (int i = 0; i < shopItemList.Types.Count; i++)
        {
            itemlist = shopItemList.Types[Random.Range(0, shopItemList.Types.Count)];

            ItemSO item;
            if (itemlist == shopItemList.Types[0])
            {
                item = shopItemList.materialList[Random.Range(0, shopItemList.materialList.Count)];
                playerInventory.Add(item);
                playerInventorySOList.materialList.Add(item);
            }
            if (itemlist == shopItemList.Types[1])
            {
                item = shopItemList.weaponList[Random.Range(0, shopItemList.weaponList.Count)];
                playerInventory.Add(item);
                playerInventorySOList.materialList.Add(item);

            }
            if (itemlist == shopItemList.Types[2])
            {
                item = shopItemList.consumableList[Random.Range(0, shopItemList.consumableList.Count)];
                playerInventory.Add(item);
                playerInventorySOList.materialList.Add(item);

            }
            if (itemlist == shopItemList.Types[3])
            {
                item = shopItemList.treasureList[Random.Range(0, shopItemList.treasureList.Count)];
                playerInventory.Add(item);
                playerInventorySOList.materialList.Add(item);

            }
        }
        playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().GotPlayerInventory(playerInventory);
    }

    private void OnSellBtnCLick()
    {
        ItemDisplayLocation();
        BuySellPanelControl(true);
        itemDisplayRectTransfom.position = shopItemDisplay.position;
        playerItemDisplay.gameObject.SetActive(true);
        shopItemDisplay.gameObject.SetActive(!playerItemDisplay.gameObject.activeSelf);
    }

    private void OnBuyBtnClick()
    {
        ItemDisplayLocation();
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
    public void ShopOpen()
    {
        shopItemDisplay.gameObject.SetActive(true);
        playerItemDisplay.gameObject.SetActive(false);
        ItemDisplayLocation();
    }
    public void PlayerOpen()
    {
        shopItemDisplay.gameObject.SetActive(false);
        playerItemDisplay.gameObject.SetActive(true);
        ItemDisplayLocation();
    }
}
