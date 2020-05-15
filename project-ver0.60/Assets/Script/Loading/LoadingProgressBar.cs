using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadingProgressBar : MonoBehaviour
{

    public static Image image;
    //public Text text;
    public TextMeshProUGUI text;

    private float targetvalue;
    private float loadingSpeed = 1;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
        image.fillAmount = 0.0f;
    }

    private void Update()
    {
        targetvalue = Loader.GetLoadingProgress();

        if (Loader.loadingAsyncOperation != null && Loader.GetLoadingProgress() >= 0.9f)
        {
            //LoadingProgress的值最大為0.9
            targetvalue = 1f;
        }
        //插值運算
        //image.fillAmount = Mathf.Lerp(image.fillAmount, targetvalue, Time.deltaTime * loadingSpeed);
        //if (Mathf.Abs(image.fillAmount - targetvalue) < 0.01f)
        //{
        //    image.fillAmount = targetvalue;
        //}
        image.fillAmount = targetvalue;

        text.text = $"{(int)(image.fillAmount * 100)}%";

        if (image.fillAmount == 1f)
        {
            Loader.loadingAsyncOperation.allowSceneActivation = true;

            Debug.Log($"finishLoading, allow: {Loader.loadingAsyncOperation.allowSceneActivation}");
        }
        //Debug.Log($"target{targetvalue} fill:{image.fillAmount}");
        //progress = 0.1~1
        //image.fillAmount = Loader.GetLoadingProgress();
        //text.text = $"{Loader.GetLoadingProgress() * 100}%";

    }
}
