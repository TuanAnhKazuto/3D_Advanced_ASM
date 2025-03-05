using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChange : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Gán VideoPlayer trong Inspector
    public string nextSceneName = "SceneOpen"; // Đặt tên Scene cần chuyển

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Khi nhấn phím Space
        {
            SceneManager.LoadScene(nextSceneName); // Chuyển Scene
        }
    }
}
