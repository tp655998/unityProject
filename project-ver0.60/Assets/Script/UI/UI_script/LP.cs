using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LP : MonoBehaviour
{
    public Image LPBar;

    void Update()
    {
        this.transform.localPosition = new Vector3((-200 + 200 * (Player_Status.Arissa.LPs.LP / Player_Status.Arissa.LPs.MaxLP)), 0.0f, 0.0f);
    }
}
