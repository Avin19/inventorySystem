using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button transcationBtn, gatherBtn, increaseQuantityBtn, decreaseQuantitybtn, confirmBtn, cancelBtn;
    [SerializeField] private RectTransform itemDisplayRectTransfom;
    [SerializeField] private RectTransform playerItemDisplay;
    [SerializeField] private RectTransform shopItemDisplay;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private ItemSO itemData;
    [SerializeField] private PlayerInventorySO playerInventorySO;
    [SerializeField] private ItemListSO shopItemList;
    [SerializeField] private RectTransform buysellPanel;
    [SerializeField] private InfoBarController infoBarController;
    [SerializeField] private BuySellController buySellController;
    [SerializeField] private RectTransform notificationDisplay;
    private int coin = 0;
    private TextMeshProUGUI transcationBtnText;


    private void OnEnable()
    {
        transcationBtn.onClick.AddListener(OnTranscationBtnClick);
        gatherBtn.onClick.AddListener(OnGatherBtnClick);
        transcationBtnText = transcationBtn.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnDisable()
    {
        transcationBtn.onClick.RemoveListener(OnTranscationBtnClick);
        gatherBtn.onClick.RemoveListener(OnGatherBtnClick);
    }
    public void ItemDisplayLocation()
    {
        infoBarController.UpdateCoinValue(coin);
        if (!playerItemDisplay.gameObject.activeSelf)
        {
            itemDisplayRectTransfom.position = playerItemDisplay.position;
            transcationBtnText.text = "Buy";

            return;
        }
        itemDisplayRectTransfom.position = shopItemDisplay.position;
        transcationBtnText.text = "Sell";
    }

    private void OnGatherBtnClick()
    {
        CheckWeight();
    }

    private void CheckWeight()
    {
        if (playerStatus.playerItemWeight >= playerStatus.maxplayerWeight)
        {

            notificationDisplay.gameObject.SetActive(true);
            Invoke(nameof(NotificationSetTrue), 1f);
        }
        else
        {
            ItemDisplayLocation();
            BuySellPanelControl(false);
            ItemDisplayHide();
            coin += Random.Range(0, 500);
            InfoBarUpdate();
            playerStatus.coin = coin;
            PlayerMaterialGather();

        }
    }

    private void NotificationSetTrue()
    {
        notificationDisplay.gameObject.SetActive(false);
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
            playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().Display();

        }

    }

    private void AddDataToInventory(ItemSO item)
    {
        playerStatus.playerItemWeight += item.weight;
        if (playerInventorySO.Inventory.Contains(item))
        {
            playerInventorySO.Inventory[playerInventorySO.Inventory.IndexOf(item)].quantity += item.quantity;
        }
        else
        {
            playerInventorySO.Inventory.Add(item);

        }

    }
    private void OnTranscationBtnClick()
    {
        ItemDisplayLocation();
        BuySellPanelControl(true);
        buySellController.SetItem(itemData, transcationBtnText.text);
        InfoBarUpdate();


    }

    private void ItemDisplayHide()
    {
        itemDisplayRectTransfom.gameObject.SetActive(false);
    }
    public void ReceiveItemInform(ItemSO itemData)
    {
        this.itemData = itemData;
    }
    private void BuySellPanelControl(bool check)
    {

        buysellPanel.gameObject.SetActive(check);
    }
    private void InfoBarUpdate()
    {
        infoBarController.UpdateCoinValue(coin);
    }

    public void ShopOpen()
    {
        shopItemDisplay.gameObject.SetActive(true);
        playerItemDisplay.gameObject.SetActive(false);
        playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().Display();
        ItemDisplayLocation();
        InfoBarUpdate();
    }
    public void PlayerOpen()
    {
        shopItemDisplay.gameObject.SetActive(false);
        playerItemDisplay.gameObject.SetActive(true);
        playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().Display();
        ItemDisplayLocation();
        InfoBarUpdate();
    }
}
