using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_cd : MonoBehaviour
{
    public float coldtime = 2; //cd時間
    private float timer = 0;//計時器初始值(經過時間)
    private Image filledImage;
    private bool isStartTimer;//是否開始計算時間
    public KeyCode keycode;
    // Start is called before the first frame update
    void Start()
    {
        filledImage = transform.Find("Skill_3_filled").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {         
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isStartTimer = true;
        }      

        if (isStartTimer)//如果計時器開始執行
        {
            timer += Time.deltaTime;//計時器時間開始往上加
            filledImage.fillAmount = (coldtime - timer) / coldtime;//冷卻時間-目前經過時間占total CD 的比例
        }
        if(timer >= coldtime)
        {
            filledImage.fillAmount = 0;
            timer = 0;
            isStartTimer = false;
        }
    }



    public void OnClick()
    {
        isStartTimer = true;
    }

}
