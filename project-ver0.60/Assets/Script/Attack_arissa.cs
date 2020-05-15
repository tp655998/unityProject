using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_arissa : MonoBehaviour
{
    Animator_Controller Anime;
    ALL_Skill skill;
    Timer t;
    public bool Magic1, Magic2, Magic3, buff1, buff2, buff3, Combo;
    public Transform TF;
    void Start()
    {
        Anime = GetComponent<Animator_Controller>();
        t = GetComponent<Timer>();
        Magic1 = false;
        Magic2 = false;
        Magic3 = false;
    }

    void Update()
    {
        /*if(Input.GetMouseButton(1))
        {
            Debug.Log("OnGround = " + Anime.OnGround);
            if (Anime.OnGround == true) Anime.OnGround = false;
            else if (Anime.OnGround == false) Anime.OnGround = true;
        }*/
        Magic1 = false;
        Magic2 = false;
        Magic3 = false;
        buff1 = false;
        buff2 = false;
        buff3 = false;

        if (Player_Status.Arissa.HPs.HP <= 0)
        {
            Anime.DMG(true);
        }        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Anime.time_int = 20;
            Anime.Status = true;
            Magic1 = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Anime.Status = true;
            Anime.time_int = 20;
            Magic2 = true;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Anime.Status = true;
            Anime.time_int = 20;
            Magic3 = true;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Anime.Status = true;
            Anime.time_int = 20;
            buff1 = true;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            Anime.Status = true;
            Anime.time_int = 20;
            buff2 = true;
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            Anime.Status = true;
            Anime.time_int = 20;
            buff3 = true;
        }
        Anime.Magic(Magic1, Magic2, Magic3, buff1, buff2, buff3);
        if (Input.GetMouseButton(0))
        {
            Combo = true;
            Anime.Status = true;
            Anime.time_int = 20;
        }
        else
        {
            Combo = false;
        }
        Anime.Atk(Combo);
        Anime.timer();
        t.Time();
        //Debug.Log("0");
        //Debug.Log("time = " + time_int);
    }
}
