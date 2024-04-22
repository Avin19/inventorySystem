using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    [SerializeField] private ItemListSO itemListSO;
    [Header("Button")]
    [SerializeField] private Button materialBtn;
    [SerializeField] private Button weaponBtn;
    [SerializeField] private Button consumableBtn;
    [SerializeField] private Button treasureBtn;
    [SerializeField] private GameObject pfItem;
    [SerializeField] private RectTransform itemHolder;



    private void Awake()
    {
        materialBtn.onClick.AddListener(OnMaterialClick);
        weaponBtn.onClick.AddListener(OnWeaponClick);
        treasureBtn.onClick.AddListener(OntreasureClick);
        consumableBtn.onClick.AddListener(OnconsumableClick);
    }

    private void OnMaterialClick()
    {
        foreach (var materialItem in itemListSO.materialList)
        {
            Item item = Instantiate(pfItem, itemHolder).GetComponent<Item>();
            item.SetSprite(materialItem.iconSprite);
            item.SetQuantityText(materialItem.quantity);
        }
    }

    private void OnWeaponClick()
    {
        foreach (var materialItem in itemListSO.weaponList)
        {
            Item item = Instantiate(pfItem, itemHolder).GetComponent<Item>();
            item.SetSprite(materialItem.iconSprite);
            item.SetQuantityText(materialItem.quantity);
        }
    }

    private void OntreasureClick()
    {
        foreach (var materialItem in itemListSO.treasureList)
        {
            Item item = Instantiate(pfItem, itemHolder).GetComponent<Item>();
            item.SetSprite(materialItem.iconSprite);
            item.SetQuantityText(materialItem.quantity);
        }
    }

    private void OnconsumableClick()
    {
        foreach (var materialItem in itemListSO.consumableList)
        {
            Item item = Instantiate(pfItem, itemHolder).GetComponent<Item>();
            item.SetSprite(materialItem.iconSprite);
            item.SetQuantityText(materialItem.quantity);
        }
    }
}
