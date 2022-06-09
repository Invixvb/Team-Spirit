using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

public class PopupAssignmentCreateWindow : EditorWindow
{
    private int _themeIndex;
    private int _levelIndex;

    private static string[] _themeArray;
    private static List<SO_Theme> _themeList;
    private static readonly string[] LevelArray = { "Level 1", "Level 2" };

    public static void Init(string[] themeArray, List<SO_Theme> themeList)
    {
        _themeArray = themeArray;
        _themeList = themeList;

        EditorWindow window = CreateInstance<PopupAssignmentCreateWindow>();

        var titleContent = new GUIContent("Create Assignment");
        window.titleContent = titleContent;

        window.position = new Rect(670, 380, 200, 100);

        window.minSize = new Vector2(200, 100);
        window.maxSize = new Vector2(200, 100);

        window.ShowModalUtility();
    }

    private void OnGUI()
    {
        _themeIndex = EditorGUILayout.Popup(_themeIndex, _themeArray);
        _levelIndex = EditorGUILayout.Popup(_levelIndex, LevelArray);

        if (GUILayout.Button("Create"))
        {
            var themeObject = CreateInstance<SO_Slide>();

            var path = AssetDatabase.GenerateUniqueAssetPath($"Assets/Resources/Slides/{_themeList[_themeIndex].name}/{LevelArray[_levelIndex]}/Slide.asset");
            AssetDatabase.CreateAsset(themeObject, path);
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = themeObject;

            switch (_levelIndex)
            {
                case 0:
                    _themeList[_themeIndex].levelOneSlides.Add(themeObject);
                    themeObject.level = 1;
                    break;
                case 1:
                    _themeList[_themeIndex].levelTwoSlides.Add(themeObject);
                    themeObject.level = 2;
                    break;
                default:
                    Debug.LogError("Level index not found");
                    break;
            }

            themeObject.themeListIndex = _themeIndex;

            Close();
        }
    }
}
