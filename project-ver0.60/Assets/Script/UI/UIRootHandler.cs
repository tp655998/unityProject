using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootHandler : MonoBehaviour
{
    void Awake()
    {
        UIManager.Instance.m_CanvasRoot = gameObject;
    }
}
