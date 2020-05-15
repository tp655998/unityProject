using UnityEngine;
using System.Collections;

public class Destroy1 : MonoBehaviour {

	public float lifetime = 2.0f;
    Collider sphere;
    void Start()
    {
        sphere = GetComponent<Collider>();
    }
    void Awake()
	{
        if (lifetime == 0) sphere.enabled = false;
        Destroy(gameObject, lifetime);
	}
}
