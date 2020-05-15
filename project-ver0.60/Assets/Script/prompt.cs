using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prompt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text_UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TransferPoint.GT == true)
            text_UI.text = "按F進行傳送";
        else
            text_UI.text = "";
    }
}
