using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitch : MonoBehaviour
{
    public static GameObject Player;


    //從Gate輸入x,y,z
    public float x = 0;
    public float y = 0;
    public float z = 0;

    public string goToTheScene;

    public void Start()
    {
        Player = GameObject.Find("Arissa");
    }

    void OnTriggerEnter(Collider other) //進入傳送點的觸發器內
    {
        if (other.CompareTag("Player"))
        {
            //座標設定
            Player_Status.playerX = x;
            Player_Status.playerY = y;
            Player_Status.playerZ = z;

            //不使用重力
            Debug.Log("gravity = false");
            Player.GetComponent<Rigidbody>().useGravity = false;
            //切換場景(包含loading畫面)
            CallLoading(goToTheScene);
        }
    }

    public static void Move()
    {
        Debug.Log("Move");
        if (Player_Status.playerX != 0) //避免一開始載入就被換位置
        {
            //改變位置
            Player.transform.position = new Vector3(Player_Status.playerX, Player_Status.playerY, Player_Status.playerZ);
        }

    }
    public static void useGravity()
    {
        Debug.Log("useGravity");
        //使用重力
        Player.GetComponent<Rigidbody>().useGravity = true;
    }
    private void CallLoading(string SceneName)
    {
        EnumSceneTransfer.LoadSceneEnum(SceneName);
    }
}
