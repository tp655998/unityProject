using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour //綁定介面
{
    private StatusModel _statusModel;
    private Transform _container;
    private Transform _statusPanel;

    private void SetStatusPanel(int n)
    {
        var prefab = Instantiate(Resources.Load<GameObject>("Team/Character")); //Prefab路徑
        prefab.transform.parent = _container;
        var toggle = prefab.GetComponent<Toggle>();

        toggle.group = _container.GetComponent<ToggleGroup>();
        Text name = prefab.transform.Find("name_bar/Text").GetComponent<Text>();
        Image img = prefab.transform.Find("Portrait").GetComponent<Image>();
        Text Lv = prefab.transform.Find("Lv/text").GetComponent<Text>();

        var player = _statusModel.Teams.playerList[n];
        name.text = player.Name;
        img.sprite = player.sprite;
        Lv.text = player.LV.ToString();


        toggle.onValueChanged.AddListener(delegate {
            if (toggle.isOn)
            {
                ToggleChange(n);
            }
        });

    }
    private void InitPlayers()
    {
        _statusPanel = GameObject.Find("Panel1").transform;
        _container = GameObject.Find("team_btn").transform;
        foreach (Transform child in _container)
        {
            Object.Destroy(child.gameObject);
        }
        for (int i = 0; i < _statusModel.Teams.playerList.Count; i++)
        {
            SetStatusPanel(i);
        }
    }
    public void ToggleChange(int index)
    {
        _statusModel.Teams.currentIndex = index;
        Debug.Log(index);
    }

    void Start()
    {
        _statusModel = new StatusModel(Resources.Load<Teams>("Team"));
        InitPlayers();
    }

    void Update()
    {
        //------------------------set current player--------------------------------------------------
        Player_Status.Arissa.HPs.HP = _statusModel.Teams.CurrentPlayer.PlayerHP;
        Player_Status.Arissa.MPs.MP = _statusModel.Teams.CurrentPlayer.PlayerMP;
        Player_Status.Arissa.Exps.Exp = _statusModel.Teams.CurrentPlayer.PlayerEXP;
        Text Soul_num = _statusPanel.transform.Find("Soul_num").GetComponent<Text>();
        Text Lv_num = _statusPanel.transform.Find("Lv_num").GetComponent<Text>();
        Lv_num.text = _statusModel.Teams.CurrentPlayer.LV.ToString();
        Soul_num.text = "no value";

        //Debug.Log(Player_Status.Arissa.HPs.HP);
        //Debug.Log(_statusModel.Teams.CurrentPlayer.PlayerHP);
        //GameObject.Find("Panel2")?.transform.gameObject.SetActive(false);
    }
}