using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Inventory Bag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    //public Text itemInfo;
    //public Slot SelectedItem;
    //public GameObject Description;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

        var toggle = slotPrefab.GetComponent<Toggle>();
        toggle.group = slotGrid.GetComponent<ToggleGroup>();
    }

    private void OnEnable()
    {
        RefreshItem();
        //instance.itemInfo.text = "";
    }

    //public static void UpdateItemInfo(string itemDescription)
    //{
    //    instance.itemInfo.text = itemDescription;
    //}

    void Update()
    {
        //RefreshItem();
        //Debug.Log(instance.Bag.itemList.Count);
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
        //newItem.itemInfo.text = item.itemInfo;
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
           if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.Bag.itemList.Count; i++)
        {
            CreateNewItem(instance.Bag.itemList[i]);
        }
    }

}
