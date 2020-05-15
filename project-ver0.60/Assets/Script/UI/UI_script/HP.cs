using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image HPBar;
    public Text HPText;
    void Update()
    {
        HPBar.fillAmount = (Player_Status.Arissa.HPs.HP / Player_Status.Arissa.HPs.MaxHP);
        if(HPText != null)
        {
            HPText.text = $"{Player_Status.Arissa.HPs.HP} / {Player_Status.Arissa.HPs.MaxHP}";
        }
    }
}
