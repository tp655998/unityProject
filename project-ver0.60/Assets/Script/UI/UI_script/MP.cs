using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP : MonoBehaviour
{
    public Image MPBar;
    public Text MPText;

    void Update()
    {
        MPBar.fillAmount = (Player_Status.Arissa.MPs.MP / Player_Status.Arissa.MPs.MaxMP);
        if(MPText != null)
        {
            MPText.text = $"{Player_Status.Arissa.MPs.MP} / {Player_Status.Arissa.MPs.MaxMP}";
        }
    }

}
