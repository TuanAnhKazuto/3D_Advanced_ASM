using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : LoadingLevel
{
    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            LoadLevel();
        }
    }
}
