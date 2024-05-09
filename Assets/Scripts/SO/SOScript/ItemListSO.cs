
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemList", menuName = "ItemList", order = 0)]
public class ItemListSO : ScriptableObject
{
    [SerializeField] private ItemInventory[] itemInventories;
    [SerializeField] private Dictionary<ItemType, List<ItemSO>> itemDic = new Dictionary<ItemType, List<ItemSO>>();

    private void OnEnable()
    {
        foreach (var item in itemInventories)
        {
            itemDic.TryAdd(item.ItemType, item.ItemList);
        }


    }
    public List<ItemSO> GetItemByType(ItemType type)
    {
        itemDic.TryGetValue(type, out var list);
        return list;
    }

}

[Serializable]
public class ItemInventory
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private List<ItemSO> itemList;

    public ItemType ItemType => itemType;
    public List<ItemSO> ItemList => itemList;
}