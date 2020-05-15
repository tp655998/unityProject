using UnityEngine;
using System;
using System.Collections.Generic;

public class Player_Status : MonoBehaviour
{
    [Header("虛擬鍵盤")]
    public static float h = 0;
    public static float v = 0;

    public static bool f1 = false;
    public static bool f2 = false;
    public static bool f3 = false;
    public static bool f4 = false;
    public static bool B = false;


    #region HP、MP、LP、Exp
    [Serializable]
    public struct HPs
    {
        private float _hp;
        public float MaxHP { get; set; }
        public float HP
        {
            get { return _hp; }

            set
            {
                _hp = value;
                if (_hp > MaxHP) _hp = MaxHP;
                else if (_hp < 0) _hp = 0;
            }
        }
    }

    [Serializable]
    public struct MPs
    {
        private float _mp;
        public float MaxMP { get; set; }
        public float MP
        {
            get { return _mp; }

            set
            {
                _mp = value;
                if (_mp > MaxMP) _mp = MaxMP;
            }
        }
    }

    [Serializable]
    public struct LPs
    {
        private float _lp;
        public float MaxLP { get; set; }
        public float LP
        {
            get { return _lp; }

            set
            {
                _lp = value;
                if (_lp > MaxLP) _lp = MaxLP;
            }
        }
    }

    [Serializable]
    public struct Exps
    {
        public float Lv { get; set; }
        public float MaxExp { get; set; }
        public float Exp { get; set; }
    }

    [Serializable]
    public struct Stuff
    {
        public Exps Exps;
        public HPs HPs;
        public MPs MPs;
        public LPs LPs;
        public bool Recovery;
        public float RecoverySpeed;
    }

    //角色
    public static Stuff Arissa, Alena, Amanada, Emma, Jessica;

    #endregion
    

    [Header("攻&防")]
    public static int PlayerATK = 100;
    public static int PlayerDEF = 100;
    public static int PlayerSPD = 100;

    [Header("迴轉")]
    public static float TurnSpeedX = 30;
    public static float TurnSpeedY = 6;

    public static float PlayerTurn = 0;
    public static float CameraTurnX = 0;
    public static float CameraTurnY = 0;

    public static float TempTurn = 0;

    [Header("速度")]
    public static float WalkSpeed = 5;
    public static float RunSpeed = 15;

    public static float playerX = 0;
    public static float playerY = 0;
    public static float playerZ = 0;


    [Header("UI")]
    //public GameObject BagObj;
    //public GameObject StoreObj;

    [Header("聲望&錢")]
    public static int prestige = 100;
    public static int money = 100;

    [Header("劇情進度")]
    public static string ProgressNext = string.Empty;

    public static bool isTalking = false;


    float i = 0;

    //==============================

    void Start()
    {
        #region Ariss 初始數值設定
        //Exp
        Arissa.Exps.Lv = 5;
        Arissa.Exps.Exp = 10;
        Arissa.Exps.MaxExp = 500;
        //HP
        Arissa.HPs.MaxHP = 100;
        Arissa.HPs.HP = 10;
        //MP
        Arissa.MPs.MaxMP = 100;
        Arissa.MPs.MP = 10;
        //LP
        Arissa.LPs.MaxLP = 100;
        Arissa.LPs.LP = 10;
        //Recovery
        Arissa.Recovery = true;
        Arissa.RecoverySpeed = 0.5f;
        #endregion

        //BagObj = GameObject.Find("Bag");
        //StoreObj = GameObject.Find("Store");
    }

    //==============================

    void Update()
    {
        //升等經驗計算
        i += Time.deltaTime;
        if (i >= 1)
        {
            if (Arissa.Exps.Exp >= Arissa.Exps.MaxExp)
            {
                Arissa.Exps.Lv += 1;
                Arissa.Exps.Exp = Arissa.Exps.Exp - Arissa.Exps.MaxExp;

                Arissa.HPs.MaxHP += 10;
                Arissa.MPs.MaxMP += 10;
                Arissa.LPs.MaxLP += 10;

                PlayerATK += 20;
                PlayerDEF += 20;
                PlayerSPD += 5;

                Arissa.Exps.MaxExp += Arissa.Exps.Lv * 1000;
            }
            i = 0;
        }

        #region Arissa數值更新
        //Arissa 回血
        if (Arissa.HPs.HP < Arissa.HPs.MaxHP & Arissa.HPs.HP > 0 & Arissa.Recovery)
        {
            Arissa.HPs.HP += (Arissa.RecoverySpeed * Arissa.HPs.MaxHP) / 100;
        }
        //Arissa 回魔
        if (Arissa.MPs.MP < Arissa.MPs.MaxMP & Arissa.MPs.MP > 0 & Arissa.Recovery)
        {
            Arissa.MPs.MP += (Arissa.RecoverySpeed * Arissa.MPs.MaxMP) / 100;
        }
        //Arissa 耐力
        if (Arissa.LPs.LP < Arissa.LPs.MaxLP & Arissa.LPs.LP > 0 & Arissa.Recovery)
        {
            Arissa.LPs.LP += Arissa.RecoverySpeed * Arissa.LPs.MaxLP / 100;
        }
        #endregion

        ////功能按鍵
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    if (f1 == false) //原本關閉的狀態下
        //    {
        //        f1 = true;    //開啟status
        //    }
        //    else
        //    {
        //        f1 = false;  //再按一次關閉status     
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.F2))
        //{
        //    if (f2 == false) //原本關閉的狀態下
        //    {
        //        f2 = true;    //開啟status
        //    }
        //    else
        //    {
        //        f2 = false;  //再按一次關閉status     
        //    }
        //    StoreObj.SetActive(f2);//開啟背包
        //}
        //if (Input.GetKeyDown(KeyCode.F3))
        //{
        //    if (f3 == false) //原本關閉的狀態下
        //    {
        //        f3 = true;    //開啟status
        //    }
        //    else
        //    {
        //        f3 = false;  //再按一次關閉status     
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.F4))
        //{
        //    if (f4 == false) //原本關閉的狀態下
        //    {
        //        f4 = true;    //開啟status
        //    }
        //    else
        //    {
        //        f4 = false;  //再按一次關閉status     
        //    }
        //}


        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    if (bag == false)
        //    {
        //        bag = true;   //開啟背包
        //    }
        //    else
        //    {
        //        bag = false;  //再按一次關閉背包   
        //    }
        //    BagObj.SetActive(bag);//開啟背包
        //}
    }
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");//獲取虛擬鍵盤輸入
        v = Input.GetAxis("Vertical");

        CameraTurnX += TurnSpeedX * Input.GetAxis("Mouse X") * Time.deltaTime;
        CameraTurnY -= TurnSpeedY * Input.GetAxis("Mouse Y") * Time.deltaTime;

        if (CameraTurnX > 360)
        {
            CameraTurnX -= 360;
        }
        if (CameraTurnX < 0)
        {
            CameraTurnX += 360;
        }

        if (CameraTurnY > 60)
        {
            CameraTurnY = 60;
        }
        if (CameraTurnY < -40)
        {
            CameraTurnY = -40;
        }

        TempTurn = CameraTurnX;

        if (Input.GetKey(KeyCode.V))
        {

        }
        else
        {
            PlayerTurn = TempTurn;
        }
    }
    void LateUpdate()
    {

    }

    //==============================

    public void SendPrestigeToFungus()
    {
        talk.FlowchartManager.SetIntegerVariable("getPrestige", prestige);
    }

    public void SendProgressToFungus()
    {
        Stage.FlowchartManager.SetStringVariable("ProgressNext", ProgressNext);
    }
}
