using System.Collections.Generic;
using ScriptableObjects;
using Unity.VisualScripting;
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

    private int _toolbarIntLevel;
    private int _toolbarIntTheme;
    private readonly string[] _levelOfDifficulty = { "Beginner", "Advanced" };

    private string[] _themeSelection;
    private readonly List<string> _themeHeaderList = new();

    public List<SO_Theme> themeList = new();
    public List<ScriptableObject> assignmentList = new();

    [MenuItem("Window/Game Customization Window")]
    public static void ShowWindow()
    {
        GetWindow<CustomizationWindow>("Game Customization");
    }

    private void Awake()
    {
        UpdateFromScriptableObjectFolder();
    }

    private void OnFocus()
    {
        GetAllThemeHeaders();
    }

    private void OnValidate()
    {
        var s = _themeSelection[_toolbarIntTheme];

        GetAllThemeHeaders();

        for (var i = 0; i < 5; i++)
        {
            if (s == _themeSelection[i])
            {
                _toolbarIntTheme = i;
            }
        }
    }

    //TODO: Create, delete theme werken
    //TODO: Create, delete assignment werken
    //TODO: Hij wil niet een nieuw aangemaakte Theme in de list zetten
    //TODO: Edit assignments laten werken

    /// <summary>
    /// Here we execute different methods to get all the scriptable objects from the path.
    /// We do this to make sure the menu gets updated with these values on the right time.
    /// </summary>
    private void UpdateFromScriptableObjectFolder()
    {
        GetScriptableObjectsFromPath(assignmentList, "ThemeOverviewSOs/");
        GetScriptableObjectsFromPath(themeList, "ThemesSOs/");
    }

    /// <summary>
    /// Here we get all the Headers from the theme scriptable objects and add them to a list.
    /// Then we add the list content to an array. So it can be integrated into the menu buttons.
    /// </summary>
    private void GetAllThemeHeaders()
    {
        _themeHeaderList.Clear();

        for (var i = 0; i < 5; i++)
        {
            var themeHeader = themeList[i].header;

            _themeHeaderList.Add(themeHeader);
        }

        _themeSelection = _themeHeaderList.ToArray();
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

        if (GUILayout.Button("Create Theme"))
        {
            Debug.Log("Clicked Button");
        }

        if (GUILayout.Button("Delete Theme"))
        {
            Debug.Log("Clicked Button");
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box");

        if (GUILayout.Button("Create Assignment"))
        {
            Debug.Log("Clicked Button");
        }

        if (GUILayout.Button("Delete Assignment"))
        {
            Debug.Log("Clicked Button");
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Edit Themes and which number will be included in the game", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(so.FindProperty("themeList"));

        GUILayout.Label("Edit Assignments", EditorStyles.boldLabel);

        _toolbarIntTheme = GUILayout.Toolbar(_toolbarIntTheme, _themeSelection);
        _toolbarIntLevel = GUILayout.Toolbar(_toolbarIntLevel, _levelOfDifficulty);

        EditorGUILayout.PropertyField(so.FindProperty("assignmentList"));

        switch (_toolbarIntLevel)
        {
            case 0:
                BeginnerTasks();
                break;
            case 1:
                AdvancedTasks();
                break;
        }

        so.ApplyModifiedProperties();
    }

    private void BeginnerTasks()
    {
    }

    private void AdvancedTasks()
    {
    }
}