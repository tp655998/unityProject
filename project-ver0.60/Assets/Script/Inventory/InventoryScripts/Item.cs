using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName; //物件名稱
    public Sprite itemImage; //物件圖片
    public int itemHeld; //物品持有數量
    [TextArea]
    public string itemInfo; //物件資訊
}
