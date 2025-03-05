using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    [SerializeField] private Slider mouseSensitivitySlider;
    [SerializeField] private Transform playerBody;
    float xRotation = 0f;

    private void Start()
    {
        mouseSensitivitySlider = GameObject.Find("SensitivitySlider").GetComponentInChildren<Slider>();

        Cursor.lockState = CursorLockMode.Locked;

        if(PlayerPrefs.HasKey("mouseSensitivity"))
        {
            LoadMouseSensitivity();
        }
        else
        {
            SetMouseSensitivity();
        }
    }

    private void Update()
    {
        RorateCam();
        SetMouseSensitivity();
    }

    public void SetMouseSensitivity()
    {
        mouseSensitivity = mouseSensitivitySlider.value;
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity);
    }

    public void LoadMouseSensitivity()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity");
        mouseSensitivitySlider.value = mouseSensitivity;
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

    public void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
