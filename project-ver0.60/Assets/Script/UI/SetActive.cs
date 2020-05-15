using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using System.Linq.Expressions;

public class SetActive : MonoBehaviour
{
    public GameObject Status; 
    public GameObject Store;
    public GameObject Bag;

    //bool down; //是否已開啟status

    void Start()
    {
        Player_Status.f1 = false; //status
        Player_Status.f2 = false; // store
        Player_Status.B = false; //bag
        //down = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) //StatusWindow
        {
            Switch(Player_Status.f1, "f1");
        }

        if (Input.GetKeyDown(KeyCode.F2))//Store
        {
            Switch(Player_Status.f2, "f2");
        }

        if (Input.GetKeyDown(KeyCode.B))//Bag
        {
            Switch(Player_Status.B, "B");
        }
    }

    private void Switch(bool KeyStatus, string key)
    {
        if (KeyStatus == false) //原本關閉的狀態下
        {
            Debug.Log($"開啟 {key}");
            UpdateBool(true, key);         
        }
        else//KeyStatus == true
        {
            Debug.Log($"關閉 {key}");
            UpdateBool(false, key);   
        }
    }

    private void UpdateBool(bool KeyStatus, string key)
    {
        switch (key)
        {
            case "f1":
                Player_Status.f1 = KeyStatus;
                Status.SetActive(KeyStatus);
                break;
            case "f2":
                Player_Status.f2 = KeyStatus;
                Store.SetActive(KeyStatus);
                break;
            case "B":
                Player_Status.B = KeyStatus;
                Bag.SetActive(KeyStatus);
                break;
            default:
                break;
        }
    }

}
