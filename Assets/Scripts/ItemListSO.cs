using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ItemList", order = 0)]
public class ItemListSO : ScriptableObject
{
    public List<ItemSO> materialList = new List<ItemSO>();
    public List<ItemSO> weaponList = new List<ItemSO>();
    public List<ItemSO> consumableList = new List<ItemSO>();
    public List<ItemSO> treasureList = new List<ItemSO>();

}