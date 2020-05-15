using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
    public void OnBtnShowClick()
    {
        UIManager.Instance.ShowPanel("Status_window");
    }
}
