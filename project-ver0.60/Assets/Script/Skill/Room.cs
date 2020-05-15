using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    Collider sphere;
    void Start()
    {
        sphere = GetComponent<Collider>();
    }
    void Update()
    {
        if(transform.localScale.x < 50)
        {
            transform.localScale += new Vector3(0.5f, 0, 0);
        }
        if (transform.localScale.y < 50)
        {
            transform.localScale += new Vector3(0, 0.5f, 0);
        }
        if (transform.localScale.z < 50)
        {
            transform.localScale += new Vector3(0, 0, 0.5f);
        }
        if(transform.localScale.x >= 50 && transform.localScale.y >= 50 && transform.localScale.z >= 50)
        {
            sphere.enabled = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            ALL_Skill.tagname = other.gameObject.name;
            Debug.Log("name = " + ALL_Skill.tagname);
        }
    }
}