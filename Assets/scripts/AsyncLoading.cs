using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBar;
    public GameObject startButton;
    public string sceneName;

    AsyncOperation operation;

    public void LoadScene()
    {
        StartCoroutine(LoadingCoroutine());
    }

    IEnumerator LoadingCoroutine()
    {
        loadingScreen.SetActive(true);

        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        loadingBar.fillAmount = 0;

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return new WaitForEndOfFrame();

            loadingBar.fillAmount = Mathf.MoveTowards(loadingBar.fillAmount, progress, Time.deltaTime);

            if (loadingBar.fillAmount >= 1) startButton.SetActive(true);
        }
    }

    public void StartScene()
    {
        operation.allowSceneActivation = true;
    }
}
