using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;


public class ItemDisplay : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private RectTransform panelTRansfrom;
    [SerializeField] private TextMeshProUGUI itemName, quantityText, descriptionText, weightText;
    [SerializeField] private MainMenuController mainMenuController;




    public void DisplayInfor(ItemSO itemSO)
    {
        panelTRansfrom.gameObject.SetActive(true);
        itemName.text = itemSO.itemDescription;
        descriptionText.text = itemSO.itemDescription;
        image.sprite = itemSO.iconSprite;
        quantityText.text = itemSO.quantity.ToString();
        weightText.text = itemSO.weight.ToString();
        mainMenuController.ReceiveItemInform(itemSO);
        mainMenuController.PLayerInventoryDisplay();



    }

}
