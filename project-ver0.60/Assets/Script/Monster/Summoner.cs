using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class Summoner : MonoBehaviour
{
    public GameObject playerUnit;           //获取玩家单位
    private Animator thisAnimator;          //自身动画组件
    private Vector3 initialPosition;        //初始位置
    public float wanderRadius = 20;         //游走半径，移动状态下，如果超出游走半径会返回出生位置
    public float alertRadius = 15;          //警戒半径，玩家进入后怪物会发出警告，并一直面朝玩家
    public float defendRadius = 13;          //自卫半径，玩家进入后怪物会追击玩家，当距离<攻击距离则会发动攻击（或者触发战斗）
    public float departureRadius = 5;        //逃離半径，玩家进入后怪物会追击玩家，当距离<攻击距离则会发动攻击（或者触发战斗）
    public float chaseRadius = 16;          //追击半径，当怪物超出追击半径后会放弃追击，返回追击起始位置

    //public float attackRange = 4;           //攻击距离
    public float farattackRange = 7                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            ;          //攻击距离
    public float walkSpeed = 2;             //移动速度
    public float runSpeed = 5;              //跑动速度
    public float turnSpeed = 0.1f;          //转身速度，建议0.1

    public float dis = 11;

    public string atkmod = "3";
    public string faratkmod = "3";

    private enum MonsterState
    {
        STAND,      //原地呼吸
        CHECK,      //原地观察
        WALK,       //移动
        WARN,       //盯着玩家
        CHASE,      //追击玩家
        ESCAPE,     //遠離玩家
        RETURN      //超出追击范围后返回
    }

    Rigidbody M_Rigidbody;

    private MonsterState currentState = MonsterState.STAND;          //默认状态为原地呼吸

    public float[] actionWeight = { 3, 2, 5 };         //设置待机时各种动作的权重，顺序依次为呼吸、观察、移动
    public float actRestTme = 10000;           //更换待机指令的间隔时间

    public float diatanceToPlayer;            //怪物与玩家的距离
    private float diatanceToInitial;           //怪物与初始位置的距离
    private Quaternion targetRotation;         //怪物的目标朝向

    private bool is_Warned = false;
    private bool is_Running = false;

    void Start()
    {
        playerUnit = GameObject.Find("Arissa");
        thisAnimator = GetComponent<Animator>();
        //保存初始位置信息
        initialPosition = gameObject.GetComponent<Transform>().position;

        M_Rigidbody = GetComponent<Rigidbody>();
        M_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        //检查并修正怪物设置
        //1. 自卫半径不大于警戒半径，否则就无法触发警戒状态，直接开始追击了
        defendRadius = Mathf.Min(alertRadius, defendRadius);
        //2. 攻击距离不大于自卫半径，否则就无法触发追击状态，直接开始战斗了
        //attackRange = Mathf.Min(defendRadius, attackRange);
        //3. 游走半径不大于追击半径，否则怪物可能刚刚开始追击就返回出生点
        wanderRadius = Mathf.Min(chaseRadius, wanderRadius);
        //4.遠離半徑必定小於追擊半徑
        departureRadius = Mathf.Min(defendRadius, departureRadius);
        //随机一个待机动作
        RandomAction();
    }
    /*void Attack(string atk)//攻擊模式
    {
        if (atk == "1")
        {
            int[] AttackWeight = { 3, 0, 0, 0 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
                //skill.ShootMagic1();
            }
            /*if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
        }
        if (atk == "2")
        {
            int[] AttackWeight = { 5, 2, 0, 0 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
                //skill.ShootMagic1();
            }
            /*if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
        }
        if (atk == "3")
        {
            int[] AttackWeight = { 3, 5, 4, 2 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("attack_short_001", true);
            }
            /*if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
                //skill.ShootMagic1();
            }
            /*if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
        }
        if (atk == "4")
        {
            int[] AttackWeight = { 0, 5, 5, 3 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if(number <= AttackWeight[0])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
                //skill.ShootMagic1();
            }
            /*if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("attack_short_001", true);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", true);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", false);
            }
        }
        if (atk == "0")
        {
            thisAnimator.SetBool("attack_short_001", false);
        }
    }*/
    void FarAttack(string atk)//攻擊模式
    {
        if (atk == "1")
        {
            int[] AttackWeight = { 3, 0, 0, 0 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("FATK", true);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", true);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", true);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", true);
            }
        }
        if (atk == "2")
        {
            int[] AttackWeight = { 5, 2, 0, 0 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("FATK", true);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", true);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", true);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", true);
            }
        }
        if (atk == "3")
        {
            int[] AttackWeight = { 3, 5, 4, 0 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("Atk", true);
                thisAnimator.SetBool("Wall", false);
                //skill.ShootMagic2();
            }

            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("Atk", false);
                thisAnimator.SetBool("Wall", true);
                //skill.ShootMagic3();
            }
            /*if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", true);
                thisAnimator.SetBool("attack_short_004", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("attack_short_001", false);
                thisAnimator.SetBool("attack_short_002", false);
                thisAnimator.SetBool("attack_short_003", false);
                thisAnimator.SetBool("attack_short_004", true);
            }*/
        }
        if (atk == "4")
        {
            int[] AttackWeight = { 0, 5, 5, 3 }; //出招比重,普攻,技一二三
            int number = Random.Range(0, AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3]);
            if (number <= AttackWeight[0])
            {
                thisAnimator.SetBool("FATK", true);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] < number && number <= AttackWeight[0] + AttackWeight[1])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", true);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] + AttackWeight[1] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", true);
                thisAnimator.SetBool("FSK3", false);
            }
            if (AttackWeight[0] + AttackWeight[1] + AttackWeight[2] < number && number <= AttackWeight[0] + AttackWeight[1] + AttackWeight[2] + AttackWeight[3])
            {
                thisAnimator.SetBool("FATK", false);
                thisAnimator.SetBool("FSK1", false);
                thisAnimator.SetBool("FSK2", false);
                thisAnimator.SetBool("FSK3", true);
            }
        }
        if (atk == "0")
        {
            thisAnimator.SetBool("Atk", false);
            thisAnimator.SetBool("Wall", false);
        }
    }
    void AnimatorState(string str)//控制動畫布林
    {
        if (str == "Idle")
        {
            thisAnimator.SetBool("Idle", true);
            thisAnimator.SetBool("Run", false);
            thisAnimator.SetBool("Walk", false);
            thisAnimator.SetBool("Dead", false);
            thisAnimator.SetBool("Call", false);
            //Attack("0");
            FarAttack("0");
        }
        if (str == "Run")
        {
            thisAnimator.SetBool("Idle", false);
            thisAnimator.SetBool("Run", true);
            thisAnimator.SetBool("Walk", false);
            thisAnimator.SetBool("Dead", false);
            thisAnimator.SetBool("Call", false);
            //thisAnimator.SetBool("Atk", false);
            //Attack("0");
            FarAttack("0");
        }
        if (str == "Walk")
        {
            thisAnimator.SetBool("Idle", false);
            thisAnimator.SetBool("Run", false);
            thisAnimator.SetBool("Walk", true);
            thisAnimator.SetBool("Dead", false);
            thisAnimator.SetBool("Call", false);
            //thisAnimator.SetBool("Atk", false);
            //Attack("0");
            FarAttack("0");
        }
        if (str == "Call")
        {
            thisAnimator.SetBool("Idle", false);
            thisAnimator.SetBool("Run", false);
            thisAnimator.SetBool("Walk", false);
            thisAnimator.SetBool("Dead", false);
            thisAnimator.SetBool("Call", true);
            //thisAnimator.SetBool("Atk", false);
            //Attack("0");
            FarAttack("0");
        }
        if (str == "Dead")
        {
            thisAnimator.SetBool("Idle", false);
            thisAnimator.SetBool("Run", false);
            thisAnimator.SetBool("Walk", false);
            thisAnimator.SetBool("Dead", true);
            thisAnimator.SetBool("Call", false);
            //thisAnimator.SetBool("Atk", false);
            //Attack("0");
            FarAttack("0");
        }
        if (str == "FarAtk")
        {
            targetRotation = Quaternion.LookRotation(new Vector3(playerUnit.transform.position.x, 0, playerUnit.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z), Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
            thisAnimator.SetBool("Idle", false);
            thisAnimator.SetBool("Run", false);
            thisAnimator.SetBool("Walk", false);
            thisAnimator.SetBool("Dead", false);
            thisAnimator.SetBool("Call", false);
            //Attack(atkmod);
            FarAttack(faratkmod);
            //Debug.Log("Atk");
            //thisAnimator.SetBool("Atk", true);
        }
    }

    /// <summary>
    /// 根据权重随机待机指令
    /// </summary>
    void RandomAction()
    {
        //更新行动时间
        //lastActTime = Time.time;
        //Debug.Log(Time.time);
        //根据权重随机
        float number = Random.Range(0, actionWeight[0] + actionWeight[1] + actionWeight[2]);
        if (number <= actionWeight[0])
        {
            currentState = MonsterState.STAND;
            //Debug.Log("stand");
            //thisAnimator.SetTrigger("Idle");
        }
        else if (actionWeight[0] < number && number <= actionWeight[0] + actionWeight[1])
        {
            currentState = MonsterState.CHECK;
            //Debug.Log("check");
            //thisAnimator.SetTrigger("Idle");
        }
        if (actionWeight[0] + actionWeight[1] < number && number <= actionWeight[0] + actionWeight[1] + actionWeight[2])
        {
            //Debug.Log("walk");
            //随机一个朝向
            targetRotation = Quaternion.Euler(0, Random.Range(1, 9) * 45, 0);
            currentState = MonsterState.WALK;
            //thisAnimator.SetTrigger("Run");
        }
    }

    void Update()
    {
        //Debug.Log("diatanceToPlayer = " + diatanceToPlayer);
        //Debug.Log(lastActTime + "last");
        /*lastActTime++;
        if (lastActTime > actRestTme)
        {
            lastActTime -= actRestTme;

            AnimatorState("Idle");

            RandomAction();        //随机切换指令
        }*/
        //Debug.Log("currentState: " + currentState);
        switch (currentState)
        {
            //待机状态，等待actRestTme后重新随机指令
            case MonsterState.STAND:
                /*if (Time.time - lastActTime > actRestTme)
                {
                    //RandomAction();         //随机切换指令
                }*/
                AnimatorState("Idle");
                //该状态下的检测指令
                EnemyDistanceCheck();
                break;

            //待机状态，由于观察动画时间较长，并希望动画完整播放，故等待时间是根据一个完整动画的播放长度，而不是指令间隔时间
            case MonsterState.CHECK:
                //if (Time.time - lastActTime > thisAnimator.GetCurrentAnimatorStateInfo(0).length)
                /*if (Time.time - lastActTime > actRestTme)
                {
                    //RandomAction();         //随机切换指令
                }*/
                //该状态下的检测指令
                AnimatorState("Idle");
                EnemyDistanceCheck();
                break;

            //游走，根据状态随机时生成的目标位置修改朝向，并向前移动
            case MonsterState.WALK:
                transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);

                /*if (Time.time - lastActTime > actRestTme)
                {
                    //RandomAction();         //随机切 换指令
                }*/
                //该状态下的检测指令
                AnimatorState("Walk");
                WanderRadiusCheck();
                break;

            //警戒状态，播放一次警告动画和声音，并持续朝向玩家位置
            case MonsterState.WARN:
                if (!is_Warned)
                {
                    AnimatorState("Idle");
                    //gameObject.GetComponent<AudioSource>().Play();
                    is_Warned = true;
                }
                //持续朝向玩家位置
                targetRotation = Quaternion.LookRotation(playerUnit.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
                //该状态下的检测指令
                WarningCheck();
                break;

            //追击状态，朝着玩家跑去
            case MonsterState.CHASE:
                if (!is_Running)
                {
                    AnimatorState("Run");
                    is_Running = true;
                }
                //Debug.Log("diatanceToPlayer =" + diatanceToPlayer);
                //Debug.Log("dis =" + dis);
                if (diatanceToPlayer > dis)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
                }

                //朝向玩家位置
                //targetRotation = Quaternion.LookRotation(playerUnit.transform.position - transform.position, Vector3.up);
                targetRotation = Quaternion.LookRotation(new Vector3(playerUnit.transform.position.x, 0, playerUnit.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z), Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
                //该状态下的检测指令
                ChaseRadiusCheck();
                break;

            //追击状态，朝着玩家跑去
            case MonsterState.ESCAPE:
                if (!is_Running)
                {
                    AnimatorState("Run");
                    is_Running = true;
                }
                //Debug.Log("diatanceToPlayer =" + diatanceToPlayer);
                //Debug.Log("dis =" + dis);                
                if (diatanceToPlayer < farattackRange)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
                }
                //朝向玩家位置
                //targetRotation = Quaternion.LookRotation(playerUnit.transform.position - transform.position, Vector3.up);
                targetRotation = Quaternion.LookRotation(new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(playerUnit.transform.position.x, 0, playerUnit.transform.position.z), Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
                AnimatorState("Call");
                //该状态下的检测指令
                ChaseRadiusCheck();
                break;
            //返回状态，超出追击范围后返回出生位置
            case MonsterState.RETURN:
                //朝向初始位置移动
                targetRotation = Quaternion.LookRotation(initialPosition - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
                transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
                //该状态下的检测指令
                AnimatorState("Run");
                ReturnCheck();
                break;
        }
    }

    /// <summary>
    /// 原地呼吸、观察状态的检测
    /// </summary>
    void EnemyDistanceCheck()
    {
        diatanceToPlayer = Vector3.Distance(playerUnit.transform.position, transform.position);

        if (diatanceToPlayer < departureRadius)
        {
            AnimatorState("Run");
            currentState = MonsterState.ESCAPE;
        }
        else if (diatanceToPlayer < defendRadius && diatanceToPlayer > dis)
        {
            AnimatorState("Run");
            currentState = MonsterState.CHASE;
        }
        else if (diatanceToPlayer < alertRadius)
        {
            currentState = MonsterState.WARN;
        }
        else AnimatorState("Idle");
    }

    /// <summary>
    /// 警告状态下的检测，用于启动追击及取消警戒状态
    /// </summary>
    void WarningCheck()
    {
        diatanceToPlayer = Vector3.Distance(playerUnit.transform.position, transform.position);

        if (diatanceToPlayer < departureRadius)
        {
            AnimatorState("Run");
            currentState = MonsterState.ESCAPE;
        }
        if (diatanceToPlayer < defendRadius && diatanceToPlayer > dis)
        {
            AnimatorState("Run");
            currentState = MonsterState.CHASE;
        }
        if (diatanceToPlayer > alertRadius)
        {
            is_Warned = false;
            RandomAction();
        }
    }

    /// <summary>
    /// 游走状态检测，检测敌人距离及游走是否越界
    /// </summary>
    void WanderRadiusCheck()
    {
        diatanceToPlayer = Vector3.Distance(playerUnit.transform.position, transform.position);
        diatanceToInitial = Vector3.Distance(transform.position, initialPosition);
                
        if (diatanceToPlayer < departureRadius)
        {
            AnimatorState("Run");
            currentState = MonsterState.ESCAPE;
        }
        else if (diatanceToPlayer < defendRadius && diatanceToPlayer > dis)
        {
            AnimatorState("Run");
            currentState = MonsterState.CHASE;
        }        
        else if (diatanceToPlayer < alertRadius)
        {
            currentState = MonsterState.WARN;
        }
        if (diatanceToPlayer > farattackRange && diatanceToPlayer < dis)
        {
            AnimatorState("FarAtk");
        }
        if (diatanceToInitial > wanderRadius)
        {
            //朝向调整为初始方向
            targetRotation = Quaternion.LookRotation(initialPosition - transform.position, Vector3.up);
        }
    }

    /// <summary>
    /// 追击状态检测，检测敌人是否进入攻击范围以及是否离开警戒范围
    /// </summary>
    void ChaseRadiusCheck()
    {
        diatanceToPlayer = Vector3.Distance(playerUnit.transform.position, transform.position);
        diatanceToInitial = Vector3.Distance(transform.position, initialPosition);
        //Debug.Log("attackRange =" + attackRange);
        //Debug.Log("diatanceToPlayer =" + diatanceToPlayer);
                
        if (diatanceToPlayer < departureRadius)
        {
            AnimatorState("Run");
            currentState = MonsterState.ESCAPE;
        }
        else if (diatanceToPlayer < defendRadius && diatanceToPlayer > dis)
        {
            AnimatorState("Run");
            currentState = MonsterState.CHASE;
        }
        if (diatanceToPlayer > farattackRange && diatanceToPlayer < dis)
        {
            AnimatorState("FarAtk");
        }
        //如果超出追击范围或者敌人的距离超出警戒距离就返回
        if (diatanceToInitial > chaseRadius || diatanceToPlayer > alertRadius)
        {
            currentState = MonsterState.RETURN;
        }
    }

    /// <summary>
    /// 超出追击半径，返回状态的检测，不再检测敌人距离
    /// </summary>
    void ReturnCheck()
    {
        diatanceToInitial = Vector3.Distance(transform.position, initialPosition);
        //如果已经接近初始位置，则随机一个待机状态
        diatanceToPlayer = Vector3.Distance(playerUnit.transform.position, transform.position);
                
        if (diatanceToPlayer < departureRadius)
        {
            AnimatorState("Run");
            currentState = MonsterState.ESCAPE;
        }
        else if (diatanceToPlayer < defendRadius && diatanceToPlayer > dis)
        {
            AnimatorState("Run");
            currentState = MonsterState.CHASE;
        }
        if (diatanceToPlayer > farattackRange && diatanceToPlayer < dis)
        {
            AnimatorState("FarAtk");
        }
        if (diatanceToInitial < 1f)
        {
            is_Running = false;
            RandomAction();
        }
    }
}