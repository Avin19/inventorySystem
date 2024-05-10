using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;


public class ItemDisplay : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private RectTransform panelTRansfrom;
    [SerializeField] private TextMeshProUGUI itemName, quantityText, descriptionText, weightText, buyText, sellText;
    [SerializeField] private MainMenuController mainMenuController;




    public void DisplayInfor(ItemSO itemSO)
    {
        panelTRansfrom.gameObject.SetActive(true); // internal plane 
        itemName.text = itemSO.itemDescription;
        descriptionText.text = "Description: " + itemSO.itemDescription;
        image.sprite = itemSO.iconSprite;
        quantityText.text = " Quantity: " + itemSO.quantity.ToString();
        weightText.text = " Weight: " + itemSO.weight.ToString();
        buyText.text = "Buying: " + itemSO.buyingPrice.ToString();
        sellText.text = "Selling: " + itemSO.sellingPrice.ToString();
        mainMenuController.ReceiveItemInform(itemSO);
        mainMenuController.ItemDisplayLocation();
    }

}
