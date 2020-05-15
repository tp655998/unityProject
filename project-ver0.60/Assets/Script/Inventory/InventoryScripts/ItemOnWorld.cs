using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem; //item
    public Inventory playerInventory; //bag

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject); //摧毀本身
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem)) //背包沒有此物品就新增這個物品
        {
            playerInventory.itemList.Add(thisItem);
            InventoryManager.CreateNewItem(thisItem);
        }
        else //持有數量+1
        {
            thisItem.itemHeld += 1;  
        }
        InventoryManager.RefreshItem();
    }
}
