using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public TextMeshProUGUI slotNum;
    public Text itemInfo;

    public void SelectedItem()
    {
        var BagItemInfo = GameObject.Find("Bag/Description/Text").GetComponent<Text>();
        var info = transform.GetComponent<Slot>().itemInfo;
        //BagItemInfo.text = info.text;
        //InventoryManager.instance.SelectedItem = this.transform.GetComponent<Slot>();
    }
}
