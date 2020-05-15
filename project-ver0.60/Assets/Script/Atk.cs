using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
    [SerializeField] GameObject m_SmallMagicEffect1, m_SmallMagicEffect2;
    MonsterWanderEnemy MWE;

    // Start is called before the first frame update
    void Start()
    {
        MWE = GetComponent<MonsterWanderEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowFireBall()
    {
        m_SmallMagicEffect1.SetActive(true);
    }

    public void ShootFireBall()
    {
        m_SmallMagicEffect1.SetActive(false);
        GameObject fireBallClone = Instantiate<GameObject>(m_SmallMagicEffect2);
        fireBallClone.transform.position = m_SmallMagicEffect1.transform.position;
        fireBallClone.transform.rotation = Quaternion.LookRotation(MWE.playerUnit.transform.position + new Vector3(0, 1.25f, 0) - m_SmallMagicEffect1.transform.position);
    }

}
