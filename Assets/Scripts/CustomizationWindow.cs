using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CustomizationWindow : EditorWindow
{ 
    private int _toolbarIntTheme;
    private int _toolbarIntLevel;

    private readonly string[] _levelOfDifficultyArray = { "Level 1", "Level 2" };

    private string[] _themeNamesArray;
    private readonly List<string> _themeHeadersList = new();

    public List<SO_Theme> themeList = new();
    public List<ScriptableObject> assignmentList = new();

    [MenuItem("Window/Game Customization Window")]
    public static void ShowWindow()
    {
        GetWindow<CustomizationWindow>("Game Customization");
    }

    private void Awake()
    {
        GetScriptableObjectsFromPath(themeList, "Themes/");
    }

    private void OnFocus()
    {
        UpdateThemeHeaders();
    }

    private void OnValidate()
    {
        RememberSelectedButton();
    }

    //Zorgen dat het niet zo system heavy is: List replacement & Anderen update method
    //Zorgen dat als je een level 2 theme hebt geselcteerd en dan de theme list order veranderd dat de assignment list update.
    //Zorgen dat wanneer Unity opstart de volgorde word opgeslagen van thema/opdracht
    //Wanneer je een assignment delete, word het niet aangepast. En staat er missing object.
    //TODO: Mooi formatten van ScriptableObjects en het menu

    /// <summary>
    /// Here we get all the Headers from the theme scriptable objects and add them to a list.
    /// Then we add the list content to an array. So it can be integrated into the menu buttons.
    /// </summary>
    private void UpdateThemeHeaders()
    {
        _themeHeadersList.Clear();

        foreach (var themeHeader in themeList.Select(theme => theme.header))
        {
            _themeHeadersList.Add(themeHeader);
        }

        _themeNamesArray = _themeHeadersList.ToArray();
    }

    /// <summary>
    /// Here we get the current index of the selected button.
    /// Then we update the theme headers so we make sure we have the latest headers.
    /// Then we check which one we have selected and set the toolbar int to it.
    /// </summary>
    private void RememberSelectedButton()
    {
        var currentSelection = _themeNamesArray[_toolbarIntTheme];

        UpdateThemeHeaders();

        for (var i = 0; i < _themeNamesArray.Length; i++)
        {
            if (currentSelection == _themeNamesArray[i])
            {
                _toolbarIntTheme = i;
            }
        }
    }

    private void GetEditButtonsSelected()
    {
        assignmentList.Clear();

        switch (_toolbarIntLevel)
        {
            case 0:
                assignmentList.AddRange(themeList[_toolbarIntTheme].levelOneSlides);
                break;
            case 1:
                assignmentList.AddRange(themeList[_toolbarIntTheme].levelTwoSlides);
                break;
            default:
                Debug.LogError("Can't reach level index");
                break;
        }
    }
    
    /// <summary>
    /// Get all the scriptable objects in a certain path, any kind of list can be given here. As well as any path.
    /// It will get all the objects in that path and place it all in the list.
    /// </summary>
    /// <param name="objectList"></param>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    private static void GetScriptableObjectsFromPath<T>(List<T> objectList, string path)
    {
        objectList.Clear();

        var type = objectList.GetType().GetGenericArguments()[0];

        var allFeedbackSOs = Resources.LoadAll(path, type);
        objectList.AddRange(allFeedbackSOs);
    }

    private void OnGUI()
    {
        var so = new SerializedObject(this);

        GUILayout.Label("Create stuff", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal("box");

        //Create a theme by pressing the button, here we create a unique asset from SO_Theme and set it to the path.
        //Then we focus it in our Project window and add it to the list.
        if (GUILayout.Button("Create Theme"))
        {
            var themeObject = CreateInstance<SO_Theme>();

            var path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Themes/Theme.asset");
            AssetDatabase.CreateAsset(themeObject, path);
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = themeObject;

            themeObject.header = themeObject.name;

            const string themeFolderPath = "Assets/Resources/Slides";
            AssetDatabase.CreateFolder(themeFolderPath, themeObject.name);
            
            var levelFolderPath = $"Assets/Resources/Slides/{themeObject.name}";
            AssetDatabase.CreateFolder(levelFolderPath, "Level 1");
            AssetDatabase.CreateFolder(levelFolderPath, "Level 2");

            themeList.Add(themeObject);
            
            UpdateThemeHeaders();
        }

        if (GUILayout.Button("Delete Theme"))
        {
            if (Selection.activeObject is SO_Theme item)
            {
                AssetDatabase.DeleteAsset($"Assets/Resources/Slides/{item.name}/Level 1");
                AssetDatabase.DeleteAsset($"Assets/Resources/Slides/{item.name}/Level 2");
                AssetDatabase.DeleteAsset($"Assets/Resources/Slides/{item.name}");
                
                var themePath = AssetDatabase.GetAssetPath(item);
                AssetDatabase.DeleteAsset(themePath);

                themeList.Remove(item);
                
                UpdateThemeHeaders();
            }
            else
                Debug.LogError("The selected object is not of type SO_Theme");
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");

        if (GUILayout.Button("Create Assignment"))
        {
            PopupAssignmentCreateWindow.Init(_themeNamesArray, themeList);
        }

        if (GUILayout.Button("Delete Assignment"))
        {
            if (Selection.activeObject is SO_Slide item)
            {
                var path = AssetDatabase.GetAssetPath(item);
                AssetDatabase.DeleteAsset(path);

                switch (item.level)
                {
                    case 1:
                        themeList[item.themeListIndex].levelOneSlides.Remove(item);
                        break;
                    case 2:
                        themeList[item.themeListIndex].levelTwoSlides.Remove(item);
                        break;
                    default:
                        Debug.LogError("Can't reach level index");
                        break;
                }
            }
            else
                Debug.LogError("The selected object is not of type SO_Slide");
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Edit Themes and which number will be included in the game", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(so.FindProperty("themeList"));

        GUILayout.Label("Edit Assignments", EditorStyles.boldLabel);

        _toolbarIntTheme = GUILayout.Toolbar(_toolbarIntTheme, _themeNamesArray);
        _toolbarIntLevel = GUILayout.Toolbar(_toolbarIntLevel, _levelOfDifficultyArray);

        if (GUI.changed)
            GetEditButtonsSelected();

        EditorGUILayout.PropertyField(so.FindProperty("assignmentList"));

        so.ApplyModifiedProperties();
    }
}
