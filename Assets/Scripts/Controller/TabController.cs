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


    private List<ItemSO> mitem = new List<ItemSO>();
    private List<ItemSO> titem = new List<ItemSO>();
    private List<ItemSO> citem = new List<ItemSO>();
    private List<ItemSO> witem = new List<ItemSO>();

    private void Awake()
    {
        materialBtn.onClick.AddListener(OnMaterialClick);
        weaponBtn.onClick.AddListener(OnWeaponClick);
        treasureBtn.onClick.AddListener(OntreasureClick);
        consumableBtn.onClick.AddListener(OnconsumableClick);
    }

    // Create a check condition as i am instantiating and destorying the item frequently

    private void OnMaterialClick()
    {
        HideItem();
        if (mitem.Count != 0)
        {
            foreach (ItemSO item in mitem)
            {
                ItemDisplay(item);

            }
        }
        else
        {
            foreach (var materialItem in itemListSO.materialList)
            {
                ItemDisplay(materialItem);
                mitem.Add(materialItem);
            }
        }
    }

    private void OnWeaponClick()
    {
        HideItem();
        if (witem.Count != 0)
        {
            foreach (ItemSO item in witem)
            {
                ItemDisplay(item);

            }
        }
        else
        {
            foreach (var wepaonItem in itemListSO.weaponList)
            {
                ItemDisplay(wepaonItem);
                witem.Add(wepaonItem);
            }
        }
    }

    private void OntreasureClick()
    {
        HideItem();
        if (titem.Count != 0)
        {
            foreach (ItemSO item in titem)
            {
                ItemDisplay(item);


            }
        }
        else
        {
            foreach (ItemSO teasureItem in itemListSO.treasureList)
            {
                ItemDisplay(teasureItem);
                titem.Add(teasureItem);
            }
        }
    }

    private void OnconsumableClick()
    {
        HideItem();
        if (citem.Count != 0)
        {
            foreach (ItemSO item in citem)
            {
                ItemDisplay(item);

            }
        }
        else
        {
            foreach (ItemSO consumableItem in itemListSO.consumableList)
            {
                ItemDisplay(consumableItem);
                citem.Add(consumableItem);
            }
        }
    }

    private void ItemDisplay(ItemSO itemSO)
    {
        Item item = Instantiate(pfItem, itemHolder).GetComponent<Item>();
        item.SetSprite(itemSO.iconSprite);
        item.SetQuantityText(itemSO.quantity);
        item.ItemDetails(itemSO);

    }
    private void HideItem()
    {
        for (int i = 0; i < itemHolder.childCount; i++)
        {
            Destroy(itemHolder.GetChild(i).gameObject);
        }
    }

}
