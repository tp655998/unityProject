using UnityEngine;

public class EnumSceneTransfer : MonoBehaviour
{
    public static void LoadSceneEnum(string SceneName)
    {
        switch (SceneName)
        {
            case "StartMenu":
                Loader.Load(Loader.Scene.StartMenu);
                break;

            case "Village":
                Loader.Load(Loader.Scene.Village);
                break;

            case "Forest":
                Loader.Load(Loader.Scene.Forest);
                break;

            case "East":
                Loader.Load(Loader.Scene.East);
                break;

            case "West":
                Loader.Load(Loader.Scene.West);
                break;

            case "Settlement":
                Loader.Load(Loader.Scene.Settlement);
                break;

            case "Empire":
                Loader.Load(Loader.Scene.Empire);
                break;
        }
    }
}
