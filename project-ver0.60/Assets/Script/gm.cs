using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gm : MonoBehaviour
{
    static gm instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            name = "thefirst";
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log($"刪除{sceneName}的{name}");
            Destroy(gameObject);
        }
        if (Player_Status.playerX != 0)
        {
            sceneswitch.useGravity();
        }

    }
}
