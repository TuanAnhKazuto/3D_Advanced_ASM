using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public GameObject gameOverPanel;
    public MouseLook mouseLook;
    int curSceneIndex;

    private void Awake()
    {
        mouseLook = GameObject.Find("Main Camera").GetComponent<MouseLook>();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        mouseLook.ShowMouse();
    }

    public void Restart()

    {
        gameOverPanel.SetActive(false);
        mouseLook.HideMouse();
        SceneManager.LoadScene(curSceneIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}