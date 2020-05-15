using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.Animations;


public class Animator_Controller : MonoBehaviour
{
    Animator Anime;
    Character_Controller player;
    public bool Backward, Walk, Run, Idle, LeftWalk, RightWalk, Jump, OnGround;
    public bool Buff1, Buff2, Buff3, Magic1, Magic2, Magic3, Combo, MidAir, Status;
    public bool Fly, Death;

    public float time_int = 0;
    public Text time_UI;
    int hit = 0;


    void Start()
    {
        Anime = GetComponent<Animator>();
        player = GetComponent<Character_Controller>();
        Walk = false;
        Run = false;
        Backward = false;
        Idle = true;
        OnGround = true;
        MidAir = true;
        Status = false;
    }
    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("Ground~~~~~~~~~~~~~");
        OnGround = true;
        Jumping(false);
    }
    public void OnCollisionExit(Collision col)
    {
        //Debug.Log("Ground~~~~~~~~~~~~~");
        OnGround = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hit")
        {
            hit++;
            if (hit > 3)
            {
                Anime.SetBool("Damage", true);
                time_int = 20;
                hit = 0;
            }
            else Anime.SetBool("Damage", false);
            Debug.Log("hit = " + hit);
        }
        else Anime.SetBool("Damage", false);
    }
    public void timer()
    {
        time_int -= 0.02f;
        time_UI.text = "攻擊狀態解除，\n倒數:" + time_int + "";
        if (Input.GetKey(KeyCode.Tab)) time_int = 0;
        if (time_int <= 0)
        {
            time_UI.text = "一般狀態\n";
            CancelInvoke("timer");
            //Debug.Log("false");
            //Arms.SetActive(false);
            Status = false;
        }
    }
    public void DMG(bool death = false)
    {
        if (death == true)
        {
            Death = true;
        }
        else
        {
            Death = false;
        }
    }

    public void Jumping(bool jump = false)
    {

        if (jump == true)
        {
            OnGround = false;
            Jump = true;
        }
        else if (OnGround == true)
        {
            Jump = false;
        }
    }

    public void Move(bool walk = false, bool run = false, bool backward = false, bool lwalk = false, bool rwalk = false, bool fly = false)
    {
        if (walk == true)
        {
            Walk = true;
        }
        else
        {
            Walk = false;
        }

        if (run == true)
        {
            Run = true;
        }
        else if (run == false)
        {
            Run = false;
        }

        if (backward == true)
        {
            Backward = true;
        }
        else
        {
            Backward = false;
        }

        if (lwalk == true)
        {
            LeftWalk = true;
        }
        else
        {
            LeftWalk = false;
        }

        if (rwalk == true)
        {
            RightWalk = true;
        }
        else
        {
            RightWalk = false;
        }
        if (fly == true)
        {
            Fly = true;
        }
        else
        {
            Fly = false;
        }
    }

    public void Atk(bool combo = false)
    {
        Combo = combo;
    }

    public void Magic(bool magic1 = false, bool magic2 = false, bool magic3 = false, bool buff1 = false, bool buff2 = false, bool buff3 = false)
    {
        if (magic1 == true)
        {
            Magic1 = true;
        }
        else
        {
            Magic1 = false;
        }
        if (magic2 == true)
        {
            Magic2 = true;
        }
        else
        {
            Magic2 = false;
        }
        if (magic3 == true)
        {
            Magic3 = true;
        }
        else
        {
            Magic3 = false;
        }
        if (buff1 == true)
        {
            Buff1 = true;
        }
        else
        {
            Buff1 = false;
        }
        if (buff2 == true)
        {
            Buff2 = true;
        }
        else
        {
            Buff2 = false;
        }
        if (buff3 == true)
        {
            Buff3 = true;
        }
        else
        {
            Buff3 = false;
        }
    }

    void Update()
    {
        Anime.SetBool("Idle", Idle);
        Anime.SetBool("Backward", Backward);
        Anime.SetBool("Walk", Walk);
        Anime.SetBool("Run", Run);
        Anime.SetBool("RightWalk", RightWalk);
        Anime.SetBool("LeftWalk", LeftWalk);
        Anime.SetBool("Jump", Jump);
        Anime.SetBool("Combo", Combo);
        Anime.SetBool("MidAir", MidAir);
        Anime.SetBool("Status", Status);
        Anime.SetBool("Fly", Fly);
        Anime.SetBool("OnGround", OnGround);
        Anime.SetBool("Magic1", Magic1);
        Anime.SetBool("Magic2", Magic2);
        Anime.SetBool("Magic3", Magic3);
        Anime.SetBool("Buff1", Buff1);
        Anime.SetBool("Buff2", Buff2);
        Anime.SetBool("Buff3", Buff3);
        Anime.SetBool("Death", Death);
    }
}