using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    public string SceneToLoad;

    void OnEnable()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }

}
