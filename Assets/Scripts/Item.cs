using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{

    [SerializeField] private Image imageSprite;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button onClickBtn;


    private ItemSO itemSO;

    private void Awake()
    {
        onClickBtn.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        GameObject itemDisplay = GameObject.FindGameObjectWithTag("ItemDisplay");

        itemDisplay.SetActive(true);


        itemDisplay.GetComponent<ItemDisplay>().DisplayInfor(itemSO);

    }

    public void SetSprite(Sprite sprite)
    {
        imageSprite.sprite = sprite;
    }
    public void SetQuantityText(int quantity)
    {
        quantityText.text = quantity.ToString();
    }
    public void ItemDetails(ItemSO itemSO)
    {
        this.itemSO = itemSO;
    }

}