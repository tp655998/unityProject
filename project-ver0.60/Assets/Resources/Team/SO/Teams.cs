using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Team", menuName = "Teams/Team")]
public class Teams : ScriptableObject
{
    public int currentIndex;
    public List<Player> playerList = new List<Player>();
    public Player CurrentPlayer { get { return playerList[currentIndex]; } }
}