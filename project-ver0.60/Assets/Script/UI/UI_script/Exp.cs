using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    public Image ExpBar;
    public Text ExpText;
    public Text Lv;
    void Update()
    {
        ExpBar.fillAmount = (Player_Status.Arissa.Exps.Exp / Player_Status.Arissa.Exps.MaxExp);
        if(ExpText != null)
        {
            ExpText.text = $"{Player_Status.Arissa.Exps.Exp} / {Player_Status.Arissa.Exps.MaxExp}";
        }
        Lv.text = Player_Status.Arissa.Exps.Lv.ToString();
    }
}
