using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPoint : MonoBehaviour
{
    public GameObject Player;

    public float x = 0;
    public float y = 0;
    public float z = 0;

    public static bool GT = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        GT = true;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Player.transform.position = new Vector3(x, y, z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GT = false;
    }

}
