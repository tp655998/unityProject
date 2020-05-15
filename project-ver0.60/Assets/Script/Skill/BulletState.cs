using UnityEngine;
using System.Collections;

public class BulletState : MonoBehaviour
{
    Attack_arissa shoot;
    public float x, y, x1, y1, speed = 6f;
    public Transform TF;
    public GameObject SEFin;
    Explosion Ep;

    void Start()
    {
        shoot = GetComponent<Attack_arissa>();
        Ep = GetComponent<Explosion>();
        x = Player_Status.CameraTurnX;
        y = Player_Status.CameraTurnY;
        Ep.time_int = 20;
    }
    void Update()
    {
        transform.position = Quaternion.Euler(y, x, 0) * new Vector3(0, 0, speed) + TF.position;
        if(Ep.time_int <= 0)
        {
            Destroy(gameObject);
        }
        Ep.timer();
    }

    public void OnTriggerEnter(Collider other)
    {        
        Instantiate(SEFin, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}