
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemList", menuName = "ItemList", order = 0)]
public class ItemListSO : ScriptableObject
{
    [SerializeField] private ItemInventory[] itemInventories;
    private Dictionary<ItemType, List<ItemSO>> itemDic = new Dictionary<ItemType, List<ItemSO>>();

    private void OnEnable()
    {
        foreach (var item in itemInventories)
        {
            itemDic.TryAdd(item.ItemType, item.ItemList);
        }


    }

}


public class ItemInventory
{
    private ItemType itemType;
    private List<ItemSO> itemList;

    public ItemType ItemType => itemType;
    public List<ItemSO> ItemList => itemList;
}