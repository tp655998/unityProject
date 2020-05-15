using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void StartGame(string SceneName)
    {
        EnumSceneTransfer.LoadSceneEnum(SceneName);
    }
}
