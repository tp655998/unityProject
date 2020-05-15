using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Teams/Skill")]
public class Skill : ScriptableObject
{
    public int Consume;
    public GameObject entity;
}
