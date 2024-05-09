using UnityEngine;

public class PlayerInterventoryController : MonoBehaviour
{

    [SerializeField] private PlayerInventorySO playerInventorySO;

    [SerializeField] private GameObject pfItem;

    private void Start()
    {
        Display();
    }
    public void Display()
    {
        //Create a check for already existing items

        foreach (ItemSO item in playerInventorySO.Inventory)
        {



            ItemDisplay(item);



        }
    }
    private void ItemDisplay(ItemSO itemSO)
    {
        Item item = Instantiate(pfItem, gameObject.transform).GetComponent<Item>();
        item.SetSprite(itemSO.iconSprite);
        item.SetQuantityText(itemSO.quantity);
        item.ItemDetails(itemSO);
    }
}
