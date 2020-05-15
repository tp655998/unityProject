using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModel
{
    private Teams _teams;
    public Teams Teams { get { return _teams; } }

    public StatusModel(Teams t)
    {
        _teams = t;
    }

    public Player selectPlayer(int index)
    {
        _teams.currentIndex = index;
        return _teams.playerList[index];
    }
    public List<Player> getAllPlayer()
    {
        return _teams.playerList;
    }
}
