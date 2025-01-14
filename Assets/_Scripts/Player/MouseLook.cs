using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    [SerializeField] private Transform playerBody;
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RorateCam();

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            ShowMouse();
        }
    }

    private void RorateCam()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
