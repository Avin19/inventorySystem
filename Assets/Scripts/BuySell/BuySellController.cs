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
    [SerializeField] private RectTransform notificationPanel;
    [SerializeField] private TabController tabController;
    [SerializeField] private InfoBarController infoBarController;

    [SerializeField] private RectTransform playerItemDisplay;
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
        quantity = (int)Mathf.Clamp(quantity, 1, item.quantity);
        quantityTxt.text = UpdateQuantity(--quantity);
    }

    private void OnAddQuantityClicked()
    {
        quantity = (int)Mathf.Clamp(quantity, 0, item.quantity - 1);
        quantityTxt.text = UpdateQuantity(++quantity);
    }

    private void OnCancelBtnClicked()
    {
        ResetQuantity();
    }

    private void OnOkBtnClicked()
    {
        //Selling 

        if (titleTxt.text == "Sell")
        {
            ReduceTheAmountONPlayerList(item);
            AddTheAmountOnShopList(item);
            //This is working fine 
        }
        //Buying 
        else
        {
            if (item.sellingPrice < playerStatus.coin)
            {
                ReduceTheAmountInShopList(item);
                PlayerItemAdd(item, quantity);
            }
            else
            {
                NotificationPanelSetTrue(" Less Money ");

            }
        }
        Invoke(nameof(ResetQuantity), 1f);
        playerItemDisplay.gameObject.GetComponentInChildren<PlayerInterventoryController>().Display();
        infoBarController.UpdateCoinValue(playerStatus.coin);
    }

    private void AddTheAmountOnShopList(ItemSO item)
    {
        if (item.itemType == ItemType.Material)
        {
            foreach (var i in shopList.materialList)
            {
                if (i.name == item.name)
                {
                    i.quantity += quantity;
                    playerStatus.playerItemWeight -= quantity * item.weight;
                }
            }
        }
        else if (item.itemType == ItemType.Weapon)
        {
            foreach (var i in shopList.weaponList)
            {
                if (i.name == item.name)
                {
                    i.quantity += quantity;
                    playerStatus.playerItemWeight -= quantity * item.weight;
                }
            }
        }
        else if (item.itemType == ItemType.Consumable)
        {
            foreach (var i in shopList.consumableList)
            {
                if (i.name == item.name)
                {
                    i.quantity += quantity;
                    playerStatus.playerItemWeight -= quantity * item.weight;
                }
            }

        }
        else if (item.itemType == ItemType.Treasure)
        {
            foreach (var i in shopList.treasureList)
            {
                if (i.name == item.name)
                {
                    i.quantity += quantity;
                    playerStatus.playerItemWeight -= quantity * item.weight;
                }
            }

        }

    }

    private void ReduceTheAmountONPlayerList(ItemSO item)
    {
        item.quantity -= quantity;
        playerStatus.coin += item.quantity * item.sellingPrice;
        playerStatus.playerItemWeight -= item.quantity * item.weight;
    }

    private void ReduceTheAmountInShopList(ItemSO item)
    {
        if (item.itemType == ItemType.Material)
        {
            foreach (var i in shopList.materialList)
            {
                if (i.name == item.name)
                {
                    i.quantity -= quantity;
                    playerStatus.coin -= quantity * item.sellingPrice;
                }
            }

        }
        else if (item.itemType == ItemType.Weapon)
        {
            foreach (var i in shopList.weaponList)
            {
                if (i.name == item.name)
                {
                    i.quantity -= quantity;
                    playerStatus.coin -= quantity * item.sellingPrice;
                }
            }
        }
        else if (item.itemType == ItemType.Consumable)
        {
            foreach (var i in shopList.consumableList)
            {
                if (i.name == item.name)
                {
                    i.quantity -= quantity;
                    playerStatus.coin -= quantity * item.sellingPrice;
                }
            }

        }
        else if (item.itemType == ItemType.Treasure)
        {
            foreach (var i in shopList.treasureList)
            {
                if (i.name == item.name)
                {
                    i.quantity -= quantity;
                    playerStatus.coin -= quantity * item.sellingPrice;
                }
            }

        }
        //Referesh the shop list
        tabController.UpdateTheData();

    }

    public void SetItem(ItemSO item, string typeofpruchase)
    {
        this.item = item;
        titleTxt.text = typeofpruchase;

    }
    private string UpdateQuantity(int _quantity)
    {
        quantity = _quantity;
        return _quantity.ToString();
    }
    private void PlayerItemAdd(ItemSO item, int _quantity)
    {

        if (playerStatus.coin > item.buyingPrice)
        {
            foreach (ItemSO i in playerInventorySO.Inventory)
            {
                if (i.name == item.name)
                {

                    item.quantity += _quantity;
                    playerStatus.coin -= i.buyingPrice;
                    playerStatus.playerItemWeight += i.quantity * i.weight;
                    RemoveZeroQuantity();
                    return;
                }
            }
            playerInventorySO.Inventory.Add(item);
            foreach (ItemSO i in playerInventorySO.Inventory)
            {
                if (i.name == item.name)
                {
                    item.quantity += _quantity;
                    playerStatus.coin -= i.buyingPrice;
                    playerStatus.playerItemWeight += i.quantity * i.weight;

                }
            }
        }
        RemoveZeroQuantity();

    }

    private void RemoveZeroQuantity()
    {
        foreach (ItemSO i in playerInventorySO.Inventory)
        {
            if (i.quantity <= 0)
            {
                playerInventorySO.Inventory.Remove(i);
            }
        }
    }

    private void ResetQuantity()
    {
        this.gameObject.SetActive(false);
        quantity = 0;
    }
    private void NotificationPanel()
    {
        notificationPanel.gameObject.SetActive(false);
    }
    private void NotificationPanelSetTrue(string message)
    {
        notificationPanel.gameObject.SetActive(true);
        notificationPanel.GetComponentInChildren<TextMeshProUGUI>().text = message;
        Invoke(nameof(NotificationPanel), 1f);

    }
}
