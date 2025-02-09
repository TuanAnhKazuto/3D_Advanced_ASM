using UnityEngine;

public class HpUILookAt : MonoBehaviour
{
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}