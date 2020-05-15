using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnStore : MonoBehaviour
{
    public Item thisItem; //item
    public Inventory playerInventory; //bag
    public int quantity = 1;
    public int price = 1;
    public Text desc;

    // Start is called before the first frame update
    void Start()
    {
        //InventoryManager.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItem()
    {
        desc = GameObject.Find("Store/Description/Text").GetComponent<Text>();
        var info = transform.GetComponent<Product>().itemInfo;
        desc.text = info.text;
        StoreManager.instance.currentItem = this.transform.GetComponent<ItemOnStore>();

        //if (Player_Status.money >= price * quantity)
        //{
        //    Player_Status.money -= price * quantity;
        //    if (!playerInventory.itemList.Contains(thisItem)) //背包沒有此物品就新增這個物品
        //    {
        //        playerInventory.itemList.Add(thisItem);
        //        InventoryManager.CreateNewItem(thisItem);
        //    }
        //    else //持有數量+1
        //    {
        //        thisItem.itemHeld += quantity;
        //    }
        //    InventoryManager.RefreshItem();
        //}
    }
}
