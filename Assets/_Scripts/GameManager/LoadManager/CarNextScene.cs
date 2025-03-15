using UnityEngine;
using UnityEngine.SceneManagement;

public class CarNextScene : LoadingLevel
{
    private void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadLevel();
        }
    }
}