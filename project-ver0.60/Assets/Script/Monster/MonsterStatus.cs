using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    [Header("血&魔")]
    public static float MonsterMaxHP = 100;
    public static float MonsterHP = 10;

    public static bool Recovery = true;
    public static float RecoverySpeed = 0.5f;

    [Header("攻&防")]
    public static int MonsterATK = 100;
    public static int MonsterDEF = 100;
    public static int MonsterSPD = 100;
    private void Update()
    {
        
    }
}
