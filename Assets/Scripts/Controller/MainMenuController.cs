
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button transcationBtn, gatherBtn, increaseQuantityBtn, decreaseQuantitybtn, confirmBtn, cancelBtn;
    [SerializeField] private RectTransform itemDisplayRectTransfom;
    [SerializeField] private RectTransform playerItemDisplay;
    [SerializeField] private RectTransform shopItemDisplay;
    [SerializeField] private List<ItemSO> playerInventory = new List<ItemSO>();
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private ItemSO itemData;
    [SerializeField] private PlayerInventorySO playerInventorySO;
    [SerializeField] private ItemListSO shopItemList;
    [SerializeField] private RectTransform buysellPanel;
    [SerializeField] private InfoBarController infoBarController;
    [SerializeField] private BuySellController buySellController;
    private int coin = 0;




    private void Awake()
    {
        transcationBtn.onClick.AddListener(OnBuyBtnClick);

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


        coin += Random.Range(0, 500);
        infoBarController.UpdateCoinValue(coin);
        playerStatus.coin = coin;

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
                AddDataToInventory(item);

            }
            if (itemlist == shopItemList.Types[1])
            {
                item = shopItemList.weaponList[Random.Range(0, shopItemList.weaponList.Count)];
                AddDataToInventory(item);
            }
            if (itemlist == shopItemList.Types[2])
            {
                item = shopItemList.consumableList[Random.Range(0, shopItemList.consumableList.Count)];
                AddDataToInventory(item);

            }
            if (itemlist == shopItemList.Types[3])
            {
                item = shopItemList.treasureList[Random.Range(0, shopItemList.treasureList.Count)];
                AddDataToInventory(item);

            }
        }
        playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().Display();

    }

    private void AddDataToInventory(ItemSO item)
    {
        // check item it is matching 
        for (int i = 0; i < playerInventorySO.Inventory.Count; i++)
        {
            if (playerInventorySO.Inventory[i] == item)
            {
                playerInventorySO.Inventory[i].quantity += item.quantity;

            }
            else
            {
                playerInventorySO.Inventory.Add(item);
            }
        }

    }



    private void OnBuyBtnClick()
    {
        ItemDisplayLocation();
        BuySellPanelControl(true);
        buySellController.SetItem(itemData);
        itemDisplayRectTransfom.position = shopItemDisplay.position;


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
