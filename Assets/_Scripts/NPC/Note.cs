using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public GameObject noteObject; // Đối tượng tờ giấy trên bàn
    public GameObject noteUI; // UI hiển thị nội dung ghi chú
    public TextMeshProUGUI textMeshProUGUI;// Hiển thị nội dung ghi chú
    private bool isNearNote = false;
    private bool isNoteOpen = false;
    private string noteContent = "Đây là nội dung của tờ giấy. Hãy đọc kỹ trước khi tiếp tục!";

    private void Start()
    {
        if (noteObject == null)
            Debug.LogError("noteObject chưa được gán trong Inspector");
        if (noteUI == null)
            Debug.LogError("noteUI chưa được gán trong Inspector");
        if (textMeshProUGUI == null)
            Debug.LogError("noteText chưa được gán trong Inspector");

        noteUI.SetActive(false); // Ẩn UI ghi chú ban đầu
    }

    private void Update()
    {
        if (isNearNote && Input.GetKeyDown(KeyCode.F))
        {
            if (!isNoteOpen)
            {
                PickUpNote();
            }
            else
            {
                CloseNote();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearNote = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearNote = false;
        }
    }

    private void PickUpNote()
    {
        if (noteObject != null)
            noteObject.SetActive(false); // Ẩn tờ giấy trên bàn

        if (noteUI != null)
        {
            noteUI.SetActive(true); // Hiển thị UI ghi chú
            if (textMeshProUGUI != null)
                textMeshProUGUI.text = noteContent; // Hiển thị nội dung ghi chú
        }
        isNoteOpen = true;
    }

    private void CloseNote()
    {
        if (noteUI != null)
            noteUI.SetActive(false); // Ẩn UI ghi chú

        isNoteOpen = false;
    }
}
