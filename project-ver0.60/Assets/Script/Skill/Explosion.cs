using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float time_int = 1;

    // Update is called once per frame
    void Update()
    {
        timer();
        if (time_int <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void timer()
    {
        time_int -= 0.02f;
        if (Input.GetKey(KeyCode.Tab)) time_int = 0;
        if (time_int <= 0)
        {
            CancelInvoke("timer");
        }
    }
}
