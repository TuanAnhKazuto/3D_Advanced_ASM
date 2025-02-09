using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    // Hàm này sẽ được gọi khi Player đi vào vùng trigger của cửa
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng va chạm có tag là "Player" không
        if (other.CompareTag("Player"))
        {
            // Chuyển đến scene "Scene01"
            SceneManager.LoadScene("Scene01");
        }
    }
}
