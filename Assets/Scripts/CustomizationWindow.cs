using UnityEditor;
using UnityEngine;

public class CustomizationWindow : EditorWindow
{
    #region Singleton pattern
    private static CustomizationWindow _instance;
    public static CustomizationWindow Instance
    {
        get 
        {
            if (!_instance)
                _instance = FindObjectOfType<CustomizationWindow>();
            return _instance;
        }
    }
    #endregion
    
    [MenuItem("Window/CustomizerWindow")]
    public static void ShowWindow()
    {
        GetWindow<CustomizationWindow>("Game Customizer");
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Header", EditorStyles.boldLabel);
    }
}
