using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

public class PopupDeleteWindow : EditorWindow
{
    private int _index;

    private static string[] _themeArray;
    private static List<SO_Theme> _themeList;

    public static void Init(string[] themeArray, List<SO_Theme> themeList)
    {
        _themeArray = themeArray;
        _themeList = themeList;

        EditorWindow window = CreateInstance<PopupDeleteWindow>();

        var titleContent = new GUIContent("Delete Theme");
        window.titleContent = titleContent;

        window.position = new Rect(700, 400, 200, 100);

        window.minSize = new Vector2(200, 100);
        window.maxSize = new Vector2(200, 100);

        window.ShowModalUtility();
    }

    private void OnGUI()
    {
        _index = EditorGUILayout.Popup(_index, _themeArray);

        if (GUILayout.Button("Delete"))
        {
            var selectedTheme = _themeList[_index];

            var path = AssetDatabase.GetAssetPath(selectedTheme);
            AssetDatabase.DeleteAsset(path);
            
            _themeList.Remove(selectedTheme);
            
            Close();
        }
    }
}
