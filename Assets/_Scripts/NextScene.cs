using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : LoadingLevel
{
    // Hàm này sẽ được gọi khi Player đi vào vùng trigger của cửa
    private void OnTriggerEnter(Collider other)
    {
        LoadLevel();
    }
}
