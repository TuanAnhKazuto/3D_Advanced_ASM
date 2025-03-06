using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu đối tượng chạm vào là người chơi
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Chuyển sang scene tiếp theo
        }
    }
}
