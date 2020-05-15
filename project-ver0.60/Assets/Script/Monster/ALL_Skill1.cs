using UnityEngine;

public class ALL_Skill1 : MonoBehaviour
{
    Wizard wiz;
    public GameObject playerUnit;
    public GameObject monster;
    [SerializeField] GameObject Point, MagicCycle_1;
    //[SerializeField] GameObject Skill_Start_1, Skill_Start_2, Skill_Start_3;
    [SerializeField] GameObject Skill_1, Skill_2, Skill_3;
    public void Start()
    {
        wiz = GetComponent<Wizard>();
        playerUnit = GameObject.Find("Arissa");
        monster = GameObject.Find("wizard");
    }
    public void Update()
    {
        if (wiz.diatanceToPlayer >= 12 || wiz.diatanceToPlayer <= 4)
        {
            Skill_3.SetActive(false);
        }
    }
    public void ShootMagic1()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_1);
        Magic.transform.position = monster.transform.position + new Vector3(0, 0.5f, 0);
    }
    public void ShootMagic2()
    {
        GameObject Magic = Instantiate<GameObject>(Skill_2);
        Magic.transform.position = playerUnit.transform.position + new Vector3(0, 9, 0);
    }
    public void ShootMagic3()
    {
        Skill_3.SetActive(true);
    }
    public void Cycle_1()
    {
        GameObject Magic = Instantiate<GameObject>(MagicCycle_1);
        Magic.transform.position = Point.transform.position;
        Magic.transform.localRotation = monster.transform.rotation;
        Magic.transform.Rotate(new Vector3(0, 180, 0));
    }
}