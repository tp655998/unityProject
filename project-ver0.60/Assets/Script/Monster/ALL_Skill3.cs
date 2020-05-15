using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALL_Skill3 : MonoBehaviour
{
    public GameObject playerUnit;
    public GameObject Monster;
    [SerializeField] GameObject point;
    [SerializeField] GameObject MagicCycle_1, MagicCycle_2, MagicCycle_3;
    [SerializeField] GameObject Skill_1, Skill_2, Skill_3;
    bool cycle1 = false;
    bool call_w = false;
    public static int num = 0;
    int count = 0;
    float number;
    public void Start()
    {
        playerUnit = GameObject.Find("Arissa");
        Monster = GameObject.Find("devil01");
    }
    private void Update()
    {        
        if(cycle1 == true)
        {
            if(count <= 0)
            {
                Instantiate<GameObject>(MagicCycle_1);
                count++;
            }
            MagicCycle_1.transform.position = point.transform.position;
            for (int i = 0; i < 2; i++)
            {
                MagicCycle_1.transform.position = MagicCycle_1.transform.position + new Vector3(0, 2, 0);                
            }
            number = MagicCycle_1.transform.position.y;
        }
        else cycle1 = false;
        if (call_w == true)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject SK1 = Instantiate<GameObject>(Skill_1);
                SK1.transform.position = Monster.transform.position + new Vector3(UnityEngine.Random.Range(-5, 5), number, UnityEngine.Random.Range(-5, 5));
                SK1.transform.localRotation = Monster.transform.rotation;
            }
            call_w = false;
        }
    }
    public void ShootMagic1()
    {
        if(num < 2)
        {
            call_w = true;
            num++;
        }
    }
    public void ShootMagic2()
    {
        GameObject SK2 = Instantiate<GameObject>(Skill_2);
        SK2.transform.position = playerUnit.transform.position + new Vector3(0, 9, 0);
    }
    public void ShootMagic3()
    {
        GameObject SK3 = Instantiate<GameObject>(Skill_3);
        SK3.transform.position = playerUnit.transform.position + new Vector3(0, 9, 0);
    }
    public void Cycle_1()
    {
        count = 0;
        cycle1 = true;
    }
}