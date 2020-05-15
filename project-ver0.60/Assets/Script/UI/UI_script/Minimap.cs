using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform target;
    //public Transform depthPlane;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, 500, target.position.z);
        cam.pixelRect = new Rect(0, 0, 200, 200);
        //depthPlane.localScale = new Vector3(cam.orthographicSize, cam.orthographicSize, cam.orthographicSize);
    }
}
