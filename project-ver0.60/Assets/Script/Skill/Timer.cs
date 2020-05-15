using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time_int = 0;
    public void Time()
    {
        time_int -= 0.02f;
        if (Input.GetKey(KeyCode.Tab)) time_int = 0;
        if (time_int <= 0)
        {
            CancelInvoke("Timer");
        }
    }
}
