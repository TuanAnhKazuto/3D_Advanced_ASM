using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour
{
    int sceneValue;

    public Slider slider;

    private void Start()
    {
        sceneValue = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadLevel(sceneValue + 1);
        }
    }
    public void LoadLevel(int levelName)
    {
        StartCoroutine(Loading(levelName));
    }

    IEnumerator Loading(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
