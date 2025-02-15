using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour
{
    int sceneValue;
    public GameObject loadPanel;
    public Image loadingFill;

    private void Start()
    {
        loadPanel.SetActive(false);
        sceneValue = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadLevel()
    {
        StartCoroutine(Loading(sceneValue + 1));
        loadPanel.SetActive(true);
    }

    IEnumerator Loading(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingFill.fillAmount = progress;
            yield return null;
        }
    }
}
