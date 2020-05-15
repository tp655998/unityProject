using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//這東西掛在Loading場景上 拿來判斷是否已載入場景
public class LoaderCallback : MonoBehaviour {

    //public static bool isFirstUpdate = true;

    private void Start()
    {
        Debug.Log("in the loading");
        Loader.LoaderCallback(); //呼叫LoaderCallback() 
    }

}
