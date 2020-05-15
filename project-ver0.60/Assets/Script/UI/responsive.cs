using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class responsive : MonoBehaviour
{
    private float width;
    private float height;

    [Header("cell x n = Grid")]
    public float scale_width = 1;
    public float scale_height = 1;

    // Use this for initialization
    void Start()
    {

    }
    private void Update()
    {
        //執行後的畫面size
        width = this.gameObject.GetComponent<RectTransform>().rect.width;
        height = this.gameObject.GetComponent<RectTransform>().rect.height;

        //設定調整過後的尺寸
        Vector2 newSize = new Vector2(width / scale_width, height / scale_height);
        this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
