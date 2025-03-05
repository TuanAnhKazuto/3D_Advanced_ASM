using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoEndSceneChange : LoadingLevel 
{
    public VideoPlayer videoPlayer;

    void Update()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        if (videoPlayer.isPlaying == false)
        {
            LoadLevel();
        }
    }

    public void Skip()
    {
        LoadLevel();
    }
}
