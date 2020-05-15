using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Loader
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene
    {
        Village, Forest, East, West, Settlement, Empire, Loading, StartMenu
    }

    private static Action onLoaderCallback;
    public static AsyncOperation loadingAsyncOperation; //非同步處理器

    public static void Load(Scene scene)
    {
        //Set the loader callback action to load the target scene
        //Loading載完才會載入目標場景
        onLoaderCallback = () =>
        {
            
            Debug.Log($"StartLoading");

            if (Player_Status.playerX != 0)
            {
                sceneswitch.Move();
            }

            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };


        // Load the loading scene  先載入Loading
        SceneManager.LoadScene(Scene.Loading.ToString());
    }


    public static IEnumerator LoadSceneAsync(Scene scene)
    {

        //yield return new WaitForEndOfFrame();


        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        //禁止載完直接過去
        loadingAsyncOperation.allowSceneActivation = false;
        Debug.Log($"allowSceneActivation: {loadingAsyncOperation.allowSceneActivation}");

        yield return loadingAsyncOperation;

        while (!loadingAsyncOperation.isDone)
        {
            Debug.Log("not isDone");
            yield return null; //暫緩一幀 下一幀繼續處理
        }
    }

    public static float GetLoadingProgress()
    {
        if (loadingAsyncOperation != null)
        {
            //Debug.Log("progress");
            return loadingAsyncOperation.progress;
        }

        else
        {
           // Debug.Log("else");
            return 0;
        }

        //return loadingAsyncOperation.progress;
    }

    public static void LoaderCallback()
    {
        // Triggered after the first Update which lets the screen refresh
        // Execute the loader callback action which will load the target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback(); //Loading載入完->執行onLoaderCallback()載入targetscene
            onLoaderCallback = null;
        }
    }

}
