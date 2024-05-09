
using UnityEngine;



public enum ItemType
{
    Material,
    Weapon,
    Consumable,
    Treasure,
}
public enum ItemRarity
{
    VeryCommon,
    Common,
    Rare,
    Epic,
    Legendary,


}
[CreateAssetMenu(fileName = "ItemSO", menuName = "Item", order = 0)]
public class ItemSO : ScriptableObject
{

    public ItemType itemType;
    public Sprite iconSprite;
    public string itemDescription;
    public int buyingPrice;
    public int sellingPrice;
    public float weight;
    public ItemRarity rarity;
    public int quantity;


}
