using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " PlayerInventory ", menuName = " Player Inventory")]
public class PlayerInventorySO : ScriptableObject
{
    [SerializeField] private List<ItemSO> playerInventory;


    public List<ItemSO> Inventory => playerInventory;
}
