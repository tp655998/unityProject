using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform Target;
    public GameObject UI;

    float z = 0;

    float Distence = 5.0f;
    float dis = 5.0f;
    float maxdis = 10.0f;

    bool touch = false;

    private Quaternion RotationEuler;
    private Vector3 CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        z = 120.0f * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;

        if (touch == false & maxdis < 10.0f)
        {
            maxdis += 0.1f;
        }
        if (touch == true & z < 0)
        {
            z = 0;
        }

        if (z < 0 & maxdis < 0)
        {
            
        }
        else
        {
            dis -= z;
        }

        dis = Mathf.Clamp(dis, 2.0f, maxdis);

        if (dis <= 2.0f)
        {
            float k = Input.GetAxis("Mouse ScrollWheel");
            if (k > 0)
            {
                Distence = -1.0f;
            }
        }
        else
        {
            Distence = dis;
        }

        if (Input.GetKey(KeyCode.M)) //按 M 開啟大地圖
        {
            transform.position = new Vector3(Target.position.x, 900, Target.position.z);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            UI.SetActive(false);//關閉UI
        }
        else
        {
            RotationEuler = Quaternion.Euler(Player_Status.CameraTurnY, Player_Status.CameraTurnX, 0);
            CameraPosition = RotationEuler * new Vector3(0, 2, -Distence) + Target.position;
            UI.SetActive(true);

            transform.rotation = RotationEuler;
            transform.position = CameraPosition;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (maxdis > 2.0f)
        {
            maxdis -= 0.02f * dis;
            dis -= 0.02f * dis;
        }
        touch = true;
    }
    void OnTriggerExit(Collider other)
    {
        touch = false;
    }
}
