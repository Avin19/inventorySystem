using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;


public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private Button spawnButton, addButton;
    [SerializeField] private Transform layoutObject;
    [SerializeField] private Transform centerofCanvas;
    [SerializeField] private GameObject itemPrefab;
    [Header("Sprites")]
    [SerializeField] private Sprite[] sprites;


    private Dictionary<string, int> itemAmounts = new Dictionary<string, int>();
    private ItemConfig itemConfig;
   

    private void Start()
    {
        
        
        // spawnButton.onClick.AddListener(() => SpawnItem("Bulb"));
        addButton.onClick.AddListener(() => AddItem("Bulb"));
        string json = Resources.Load<TextAsset>("ItemConfig").text;
        itemConfig = JsonUtility.FromJson<ItemConfig>(json);
        //Debug.Log(json);
        int i =0 ;
        foreach (Item item in itemConfig.items)
        {
            itemAmounts.Add(item.itemName, 0);
            Transform Itemtransfrom = Instantiate(itemPrefab, layoutObject).GetComponent<Transform>();
            Itemtransfrom.gameObject.name = item.itemName;
            Itemtransfrom.GetComponent<Image>().sprite = sprites[i];
            Itemtransfrom.Find("maxcapacity").GetComponent<TextMeshProUGUI>().text = item.maxCapacity.ToString();
            Itemtransfrom.Find("capcity").GetComponent<TextMeshProUGUI>().text = "0";
            Itemtransfrom.GetComponent<Button>().onClick.AddListener(() => AddItem(item.itemName));
            i++;

        }
    }

    private void Update()
    {
        UpdateInventoryUI();
       if(Input.GetKeyDown(KeyCode.Space))
       {
        SpawnItem("Bulb");
       }
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

            {
                
                itemAmounts[itemName]++;
                layoutObject.Find(itemName).Find("capcity").GetComponent<TextMeshProUGUI>().text = itemAmounts[itemName].ToString();

            }
        }
    }
    public void SpawnItem(string itemName)
    {
        if (itemAmounts.ContainsKey(itemName) && itemAmounts[itemName] > 0)
        {

            GameObject itemPrefab = Resources.Load<GameObject>(itemConfig.items.Find(i => i.itemName == itemName).itemName);


            if (itemPrefab != null)
            {

                Instantiate(itemPrefab, transform.position + new Vector3(Random.Range(-400,400),Random.Range(-400,400),0f), Quaternion.identity, centerofCanvas);


                itemAmounts[itemName]--;
                layoutObject.Find(itemName).Find("capcity").GetComponent<TextMeshProUGUI>().text = itemAmounts[itemName].ToString();
            }
            else
            {
                Debug.LogError($"Prefab for {itemName} is null.");
            }
        }
    }
}