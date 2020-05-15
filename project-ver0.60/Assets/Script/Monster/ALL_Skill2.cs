using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALL_Skill2 : MonoBehaviour
{
    public GameObject playerUnit;
    public GameObject Monster;
    [SerializeField] GameObject SS_1, SS_2, SS_3;
    [SerializeField] GameObject Skill_1_r, Skill_1_l, Skill_2, Skill_3, Call;
    bool call_z = false;
    public static int count = 0;
    public void Start()
    {
        playerUnit = GameObject.Find("Arissa");
        Monster = GameObject.Find("Zombie2");
    }
    private void FixedUpdate()
    {
        if(call_z == true)
        {            
            for(int i = 0; i < 6; i++)
            {
                GameObject CALL = Instantiate<GameObject>(Call);
                CALL.transform.position = SS_3.transform.position + new Vector3(UnityEngine.Random.Range(-5, 5), 0, UnityEngine.Random.Range(-5, 5));
                CALL.transform.localRotation = Monster.transform.rotation;
            }
            call_z = false;
        }
    }
    public void ShootMagic1()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_1_r);
        Magic.transform.position = SS_1.transform.position;
        Magic.transform.localRotation = Monster.transform.rotation;
        Magic.transform.Rotate(new Vector3(0, 0, 0));
    }
    public void ShootMagic2()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_1_l);
        Magic.transform.position = SS_2.transform.position;
        Magic.transform.localRotation = Monster.transform.rotation;
        Magic.transform.Rotate(new Vector3(0, 0, 0));
    }
    public void ShootMagic3()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_3);
        Magic.transform.position = SS_3.transform.position;
        Magic.transform.localRotation = Monster.transform.rotation;
        GameObject Magic2 = Instantiate<GameObject>(Skill_3);
        Magic2.transform.position = SS_3.transform.position;
        Magic2.transform.localRotation = Monster.transform.rotation;
        Magic2.transform.Rotate(new Vector3(0, 180, 0));
        if(ALL_Skill2.count <= 1)
        {
            call_z = true;
            ALL_Skill2.count++;
        }
        else call_z = false;
    }
    public void ShootMagic4()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_2);
        Magic.transform.position = SS_2.transform.position;
        Magic.transform.localRotation = Monster.transform.rotation;
        Magic.transform.Rotate(new Vector3(0, 180, 0));
    }
}