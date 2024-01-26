using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private Button spawnButton, addButton;


    private Dictionary<string, int> itemAmounts = new Dictionary<string, int>();
    private ItemConfig itemConfig;

    private void Start()
    {

        spawnButton.onClick.AddListener(() => SpawnItem("Bulb"));
        addButton.onClick.AddListener(() => AddItem("Bulb"));
        string json = Resources.Load<TextAsset>("ItemConfig").text;
        itemConfig = JsonUtility.FromJson<ItemConfig>(json);
        //Debug.Log(json);

        foreach (Item item in itemConfig.items)
        {
            itemAmounts.Add(item.itemName, 0);
        }
    }
    private void Update()
    {
        UpdateInventoryUI();
    }
    private void UpdateInventoryUI()
    {
        string inventoryInfo = "Inventory : \n";
        foreach (var kvp in itemAmounts)
        {
            inventoryInfo += $"{kvp.Key}:{kvp.Value}\n";

        }
        inventoryText.text = inventoryInfo;
    }
    public void AddItem(string itemName)
    {
        if (itemAmounts.ContainsKey(itemName))
        {
            if (itemAmounts[itemName] < itemConfig.items.Find(i => i.itemName == itemName).maxCapacity)
            { itemAmounts[itemName]++; }
        }
    }
    public void SpawnItem(string itemName)
    {
        if (itemAmounts.ContainsKey(itemName) && itemAmounts[itemName] > 0)
        {
            // Load prefab from Resources folder
            GameObject itemPrefab = Resources.Load<GameObject>(itemConfig.items.Find(i => i.itemName == itemName).itemName);

            // Check if the prefab is not null before instantiating
            if (itemPrefab != null)
            {
                // Spawn item prefab in the scene
                Instantiate(itemPrefab, transform.position, Quaternion.identity,transform);

                // Decrease item count
                itemAmounts[itemName]--;
            }
            else
            {
                Debug.LogError($"Prefab for {itemName} is null.");
            }
        }
    }
}