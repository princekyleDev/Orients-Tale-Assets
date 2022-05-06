using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadingScreenPlain : MonoBehaviour
{
    public GameObject loadingScreen;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchrounously(sceneIndex));

    }

    IEnumerator LoadAsynchrounously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
