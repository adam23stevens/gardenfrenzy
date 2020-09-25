using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public int LoadingTimeSeconds;

    private int _sceneIndex;

    void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (_sceneIndex == 0)
        {
            StartCoroutine(HandleLoadSceneToMenu());
        }
    }

    IEnumerator HandleLoadSceneToMenu()
    {
        yield return WaitRoutine(LoadingTimeSeconds);
        LoadNextScene();
    }

    private IEnumerator WaitRoutine(int waitTimeSeconds)
    {
        yield return new WaitForSeconds(waitTimeSeconds);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_sceneIndex + 1);
    }
}
