using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALL_Skill : MonoBehaviour
{
    Timer t;
    public GameObject Monster;
    public static string tagname = "default";
    public GameObject PlayerUnit;//獲取角色物件
    [SerializeField] GameObject Skill_Start_1, Skill_Start_2, Skill_Start_3, Skill_Start_4, Skill_Start_5, Skill_Start_6;
    [SerializeField] GameObject Skill_1, Skill_2, Skill_3, Skill_4, Skill_5, Skill_6;
    [SerializeField] GameObject Combo1, Combo2, Combo3;
    bool col = false;
    public static bool MC1, MC2, MC3, BF1, BF2, BF3;
    public void Start()
    {
        t = GetComponent<Timer>();
        PlayerUnit = GameObject.Find("Arissa");
        Monster = GameObject.Find(tagname);
        MC1 = false;
        MC2 = false;
        MC3 = false;
        BF1 = false;
        BF2 = false;
        BF3 = false;
    }
    public void Update()
    {
        Monster = GameObject.Find(tagname);        
        t.Time();
        if (t.time_int <= 0)
        {
            BuffMagic1_False();
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            if (col == true)
            {
                gameObject.GetComponent<SphereCollider>().enabled = true;
                col = false;
            }
            else
            {
                gameObject.GetComponent<SphereCollider>().enabled = false;
                col = true;
            }
        }
    }
    public void FixedUpdate()
    {
        if(MC1 == true)
        {
            GameObject Magic = Instantiate<GameObject>(Skill_1);
            Magic.transform.position = Skill_Start_1.transform.position;
        }
        if (MC2 == true)
        {
            GameObject Magic = Instantiate<GameObject>(Skill_2);
            Magic.transform.position = Skill_Start_2.transform.position;
        }
        if (MC3 == true)
        {
            GameObject Magic = Instantiate<GameObject>(Skill_3);
            Magic.transform.position = Skill_Start_3.transform.position;
        }
    }
    public void ShootMagic1()
    {
        MC1 = true;
    }
    public void ShootMagic2()
    {
        MC2 = true;
    }
    public void ShootMagic3()
    {
        MC3 = true;
    }
    public void BuffMagic3()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_6);
        Magic.transform.position = Skill_Start_6.transform.position;
    }
    public void BuffMagic1_True()
    {
        Skill_4.SetActive(true);
        t.time_int = 10;
    }
    public void BuffMagic1_False()
    {
        Skill_4.SetActive(false);
    }
    public void ShootCombo_1()
    {
        GameObject Magic = Instantiate<GameObject>(Combo1);
        Magic.transform.position = Monster.transform.position;
    }
    public void ShootCombo_2()
    {
        GameObject Magic = Instantiate<GameObject>(Combo2);
        Magic.transform.position = Monster.transform.position;
        Magic.transform.localRotation = PlayerUnit.transform.rotation;
        Magic.transform.Rotate(new Vector3(0, 180, 0));
    }
    public void ShootCombo_3()
    {
        GameObject Magic = Instantiate<GameObject>(Combo3);
        Magic.transform.position = Monster.transform.position;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            tagname = other.gameObject.name;
            //Debug.Log("name = " + tagname);
        }
        else tagname = "default";
    }
}