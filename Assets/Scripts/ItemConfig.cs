using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item 
{
    public string itemName;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public int maxCapacity;

}
[System.Serializable]
public class ItemConfig
{
    public List<Item> items;
}
    

