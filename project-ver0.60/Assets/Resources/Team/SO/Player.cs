using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Teams/Player")]
public class Player : ScriptableObject
{
    public string Name;
    public int PlayerMaxHP = 100;
    public int PlayerMaxMP = 100;
    public int PlayerMaxLP = 100;

    public int MaxHP = 100;
    public int MaxMP = 100;
    public int MaxLP = 100;

    public int PlayerHP = 100;
    public int PlayerMP = 100;
    public int PlayerLP = 100;

    public int PlayerLV = 1;
    public int PlayerEXP = 0;
    public int PlayerMaxEXP = 1000;

    public int LV = 1;
    public int EXP = 0;
    public int MaxEXP = 1000;

    public int PlayerATK = 100;
    public int PlayerDEF = 100;
    public int PlayerSPD = 100;

    public bool recovery = true;
    //public Sprite portrait;
    public Sprite sprite;

    public GameObject entity;
    public List<Skill> skillList = new List<Skill>();
}
