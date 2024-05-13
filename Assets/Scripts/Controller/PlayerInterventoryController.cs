using UnityEngine;
using UnityEngine.UI;

public class PlayerInterventoryController : MonoBehaviour
{

    [SerializeField] private PlayerInventorySO playerInventorySO;

    [SerializeField] private GameObject pfItem;

    public void Display()
    {
        //Create a check for already existing items
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (ItemSO item in playerInventorySO.Inventory)
        {
            ItemDisplay(item);
        }
    }
    private void ItemDisplay(ItemSO itemSO)
    {
        if (itemSO.quantity > 0)
        {
            Item item = Instantiate(pfItem, gameObject.transform).GetComponent<Item>();
            item.SetSprite(itemSO.iconSprite);
            item.SetQuantityText(itemSO.quantity);
            item.ItemDetails(itemSO);
        }
    }
}
