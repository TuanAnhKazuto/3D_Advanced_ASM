using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateScriptShortcut
{
    [MenuItem("Assets/Create New C# Script #&c")] 
    private static void CreateNewScript()
    {
        // Lấy đường dẫn thư mục đang chọn
        string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (string.IsNullOrEmpty(folderPath))
        {
            folderPath = "Assets"; // Nếu không chọn thư mục nào, mặc định là "Assets"
        }
        else if (!Directory.Exists(folderPath))
        {
            folderPath = Path.GetDirectoryName(folderPath); // Nếu chọn file, lấy thư mục chứa file
        }

        // Hiển thị hộp thoại để nhập tên file
        string filePath = EditorUtility.SaveFilePanelInProject(
            "Create New Script",      // Tiêu đề của hộp thoại
            "NewScript.cs",           // Tên mặc định
            "cs",                     // Định dạng file
            "Enter a name for the new script", // Gợi ý cho người dùng
            folderPath                // Đường dẫn mặc định
        );

        // Nếu người dùng nhấn "Cancel" hoặc không nhập gì, thoát khỏi hàm
        if (string.IsNullOrEmpty(filePath))
        {
            return;
        }

        // Tên file mà người dùng nhập (không bao gồm đường dẫn)
        string scriptName = Path.GetFileNameWithoutExtension(filePath);

        // Ghi nội dung mặc định vào file script
        File.WriteAllText(filePath, GetDefaultScriptTemplate(scriptName));

        // Làm mới cửa sổ Project và chọn script vừa tạo
        AssetDatabase.Refresh();
        Selection.activeObject = AssetDatabase.LoadAssetAtPath<MonoScript>(filePath);
    }

    // Nội dung mặc định của script mới
    private static string GetDefaultScriptTemplate(string scriptName)
    {
        return $@"using UnityEngine;

public class {scriptName} : MonoBehaviour
{{
    
}}";
    }
}
