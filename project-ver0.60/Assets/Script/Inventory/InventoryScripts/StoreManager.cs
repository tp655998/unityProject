using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;
    public Inventory Store;
    public GameObject Product_Grid;
    public Product Product_Prefab;
    public ItemOnStore currentItem;
    public Text multiQuantity;
    public int Total;
    public GameObject MultiBuy_Window;
    public GameObject Error_Window;
    //public Text itemInfo;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
        //window = GameObject.Find("Store/Buy_Window");
        //window.SetActive(false);
        //Error_Window = GameObject.Find("Store/Error_Window");
        //Error_Window.SetActive(false);

        multiQuantity.GetComponent<InputField>().onValueChanged.AddListener(
            delegate {
                if (!currentItem) return;

                var source = GameObject.Find("Store/Buy_Window/Buy_num").GetComponent<InputField>();
                var result = GameObject.Find("Store/Buy_Window/Total_num").GetComponent<Text>();

                int t;
                //Debug.Log(source.text);
                //Debug.Log(int.TryParse(source.text, out t));
                
                if(!string.IsNullOrWhiteSpace(source.text) && int.TryParse(source.text ,out t))
                {
                    var playerInventory = currentItem.playerInventory;
                    var thisItem = currentItem.GetComponent<Product>().slotItem;
                    var price = currentItem.price;
                    var quantity = Convert.ToInt32(source.text);
                    Total = price * quantity;

                    result.text = Total.ToString();
                }
                else if (string.IsNullOrWhiteSpace(source.text))
                {
                    result.text = "0";
                }
            });
    }

    private void OnEnable()
    {
        RefreshItem();
    }

    public static void CreateNewItem(Item item)
    {
        //Product newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        Product newItem = Instantiate(instance.Product_Prefab, instance.Product_Grid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.Product_Grid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        //newItem.slotNum.text = item.itemHeld.ToString();
        newItem.itemInfo.text = item.itemInfo.ToString();
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.Product_Grid.transform.childCount; i++)
        {
            if (instance.Product_Grid.transform.childCount == 0)
                break;
            Destroy(instance.Product_Grid.transform.GetChild(i).gameObject);

        }
        for (int i = 0; i < instance.Store.itemList.Count; i++)
        {
            CreateNewItem(instance.Store.itemList[i]);
        }
    }
    public void buy()
    {
        var playerInventory = currentItem.playerInventory;
        var thisItem = currentItem.GetComponent<Product>().slotItem;
        var price = currentItem.price;
        var quantity = currentItem.quantity;

        if (Player_Status.money >= price * quantity)
        {
            Player_Status.money -= price * quantity;
            //Debug.Log(thisItem);
            //Debug.Log(currentItem.desc.text);
            if (!playerInventory.itemList.Contains(thisItem)) //背包沒有此物品就新增這個物品
            {
                playerInventory.itemList.Add(thisItem);
                InventoryManager.CreateNewItem(thisItem);
            }
            else //持有數量+1
            {
                thisItem.itemHeld += quantity;
            }
            InventoryManager.RefreshItem();
        }
    }
    public void buys()
    {
        MultiBuy_Window.SetActive(true);

    }
    public void buysConfirm()
    {
        var source = GameObject.Find("Store/Buy_Window/Buy_num").GetComponent<InputField>();
        if (string.IsNullOrWhiteSpace(source.text)) return;

        var playerInventory = currentItem.playerInventory;
        var thisItem = currentItem.GetComponent<Product>().slotItem;
        var price = currentItem.price;
        var quantity = Convert.ToInt32(source.text);
        Total = price * quantity;

        if (Player_Status.money >= Total)
        {
            Player_Status.money -= Total;
            Debug.Log(thisItem);
            Debug.Log(currentItem.desc.text);
            if (!playerInventory.itemList.Contains(thisItem)) //背包沒有此物品就新增這個物品
            {
                playerInventory.itemList.Add(thisItem);
                InventoryManager.CreateNewItem(thisItem);
            }
            else //持有數量+1
            {
                thisItem.itemHeld += quantity;
            }
            InventoryManager.RefreshItem();
        }
        else
        {

            Error_Window.SetActive(true);
            //Debug.LogError("滾開～窮鬼");
        }
        //MultiBuy_Window.SetActive(false);
    }
}
