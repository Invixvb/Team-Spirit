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
    private readonly string[] _themeSelection = { "Samenwerken", "Samen een Team", "Positieve emoties", "Ontmoeten", "Communicatie" }; //TODO: Header van de array van themes pakken.
    
    public List<SO_ThemeOverview> themeOverviewSlideList = new();
    public List<SO_Feedback> feedbackSlideList = new();
    
    public List<SO_Info> beginnerInfoSlideList = new();
    public List<SO_Info> advancedInfoSlideList = new();

    [MenuItem("Window/GameCustomizationWindow")]
    public static void ShowWindow()
    {
        GetWindow<CustomizationWindow>("Game Customization");
    }
    
    public void Awake()
    {
        GetAllScriptableObjectsInFolder(feedbackSlideList, "FeedbackSOs/");
        GetAllScriptableObjectsInFolder(themeOverviewSlideList, "ThemeOverviewSOs/");
    }

    private void GetAllScriptableObjectsInFolder<T>(List<T> objectList, string path)
    {
        objectList.Clear();

        var type = objectList.GetType().GetGenericArguments()[0];
        
        var allFeedbackSOs = Resources.LoadAll(path, type);
        objectList.AddRange(allFeedbackSOs);
    }
    
    private void OnGUI()
    {
        var so = new SerializedObject(this);

        GUILayout.Label("Header", EditorStyles.boldLabel);
        
        //TODO: Create/Remove theme button - Update lists
        //TODO: Create/Remove assignment button - Update lists
        
        EditorGUILayout.PropertyField(so.FindProperty("feedbackSlideList"));
        EditorGUILayout.PropertyField(so.FindProperty("themeOverviewSlideList"));
        
        //TODO: Elke theme heeft een eigen list met slides, en de volgorde hoe het daar staat is hoe het werkt.
        //Maybe moet ik de type aanpassen naar type slide en daar een enum met types.
        
        //TODO: Theme editing button, dan klik je op een theme die er is
        //TODO: Feedback en Theme overview slide list. - Theme overview hoeft maybe niet in een list
        //TODO: Dan krijg je de de difficulty daaronder, en daarna de opdrachten daarvan
        
        _toolbarIntLevel = GUILayout.Toolbar(_toolbarIntLevel, _levelOfDifficulty);
        _toolbarIntTheme = GUILayout.Toolbar(_toolbarIntTheme, _themeSelection);

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
