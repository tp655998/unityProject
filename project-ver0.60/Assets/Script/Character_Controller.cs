using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    public GameObject PlayerUnit;//獲取角色物件
    public GameObject Terrain;//獲取地板物件
    
    Vector3 movement;//移動目標地點
    Rigidbody PlayerRigidbody;//角色剛體

    public static int RunSpeed = 10;//跑步速度
    public static int MoveSpeed = 5;//移動速度
    public static int RotateSpeed = 5;//迴轉速度

    public float h = 0;
    public float v = 0;
    public bool walk, run, backward, rwalk, lwalk, jump, fly;

    float x = 0;
    float tempx = 0;

    Animator_Controller Anime;

    void Start()
    {
        PlayerRigidbody = PlayerUnit.GetComponent<Rigidbody>();
        Anime = GetComponent<Animator_Controller>();

        PlayerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        //Cursor.visible = false;//隱藏滑鼠
        //Cursor.lockState = CursorLockMode.Locked;
        walk = false;
        run = false;
        backward = false;
        rwalk = false;
        lwalk = false;
        jump = false;
        fly = false;
    }

    void Update()
    {
        if (!Player_Status.isTalking)
        {
            Animetor(); 
        }            
    }
    

    void FixedUpdate()
    {
        if(Player_Status.isTalking)
        {
            /*h = 0;
            v = 0;*/
            PlayerRigidbody.Sleep();
            //Cursor.visible = true;//顯示滑鼠
            //Cursor.lockState = CursorLockMode.None;
        }
        else
        {       
            MoveFunction();
            TurnFunction();
            //Cursor.visible = false;//隱藏滑鼠
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Animetor()
    {
        if (Input.GetKey(KeyCode.W))
        {
            walk = true;
        }
        else
        {
            walk = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        else
        {
            backward = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rwalk = true;
        }
        else
        {
            rwalk = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            lwalk = true;
        }
        else
        {
            lwalk = false;
        }
        Anime.Jumping(jump);
        Anime.Move(walk, run, backward, lwalk, rwalk, fly);
    }

    void MoveFunction()
    {
        Vector3 GlobalDirectionForward = PlayerUnit.transform.TransformDirection(Vector3.forward);
        Vector3 ForwardDirection = Player_Status.v * GlobalDirectionForward;//前後向量

        Vector3 GlobalDirectionRight = PlayerUnit.transform.TransformDirection(Vector3.right);
        Vector3 RightDirection = Player_Status.h * GlobalDirectionRight;//左右向量

        
        if (Input.GetKey(KeyCode.LeftShift) && Player_Status.Arissa.LPs.LP > 2)
        {
            if(Anime.OnGround == true)
            {
                movement = (ForwardDirection + RightDirection) * Player_Status.RunSpeed * Time.deltaTime;
                //Player_Status.PlayerLP -= 0.2f;
                run = true; //跑動畫啟動
            }
            else
            {
                movement = (ForwardDirection + RightDirection) * Player_Status.RunSpeed * 1.5f * Time.deltaTime;
                PlayerRigidbody.AddForce(Vector3.up * 6.0f);
                //Player_Status.PlayerLP -= 0.2f;
                fly = true; //滑翔動畫
            }
        }
        else
        {
            movement = (ForwardDirection + RightDirection) * Player_Status.WalkSpeed * Time.deltaTime;
            run = false;//跑動畫關閉
            fly = false;//滑翔動畫
        }

        PlayerRigidbody.MovePosition(transform.position + movement);//剛體移動到指定位置

        if (Input.GetKeyDown(KeyCode.Space) & Player_Status.Arissa.LPs.LP > 5)//空白跳躍
        {
            //num = 200;
            PlayerRigidbody.velocity = Vector3.up * 10.0f;
            Player_Status.Arissa.LPs.LP -= 5;
            jump = true;//跳動畫
            Anime.OnGround = false;
            Anime.MidAir = true;
        }
        else
        {
            /*num--;
            if (num == 0)
            {
                jump = false;//跳動畫
            }*/
            jump = false;//跳動畫
        }
    }
    void TurnFunction()
    {
        transform.rotation = Quaternion.Euler(0, Player_Status.PlayerTurn, 0);
    }  
}
