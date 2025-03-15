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
    bool isLoad;

    protected virtual void Start()
    {
        loadingFill.fillAmount = 0;
        loadPanel.SetActive(false);
        isLoad = false;
        sceneValue = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadLevel()
    {
        if (isLoad) return;
        loadPanel.SetActive(true);
        StartCoroutine(Loading(sceneValue + 1));
        isLoad = true;
    }

    IEnumerator Loading(int SceneIndex)
    {
        loadPanel.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingFill.fillAmount = progress;
            yield return null;
        }
    }
}
