using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTabView : MonoBehaviour
{
    [SerializeField] private Button materialBtn, weaponBtn, consumableBtn, treasureBtn;
    [SerializeField] private GameObject pfItem;
    [SerializeField] private RectTransform itemHolder;
    // [SerializeField] private List<ItemDic> itemListSO = new List<ItemDic>();

    public Button MaterialButton => materialBtn;
    public Button WeaponButton => weaponBtn;
    public Button ConsumableButton => consumableBtn;
    public Button TreasureButton => treasureBtn;



}
