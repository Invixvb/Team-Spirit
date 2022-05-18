using System.Collections.Generic;
using ScriptableObjects;
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

    private int _toolbarInt;
    private readonly string[] _levelOfDifficulty = { "Beginner", "Advanced" };
    private readonly string[] _themeSelection = {  }; //TODO: Header van de array van themes pakken.
    
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
        var allFeedbackSOs = Resources.LoadAll<SO_Feedback>("FeedbackSOs/");
        feedbackSlideList.AddRange(allFeedbackSOs);
    }
    
    private void OnGUI()
    {
        var so = new SerializedObject(this);

        GUILayout.Label("Header", EditorStyles.boldLabel);
        
        //TODO: Create/Remove theme button - Update lists
        //TODO: Create/Remove assignment button - Update lists - Maybe doen met buttons van list toevoegen
        //dat die dan automatisch een nieuwe aanmaakt en erin zet.
        
        EditorGUILayout.PropertyField(so.FindProperty("feedbackSlideList"));
        
        //TODO: Elke theme heeft een eigen list met slides, en de volgorde hoe het daar staat is hoe het werkt.
        //Maybe moet ik de type aanpassen naar type slide en daar een enum met types.
        
        //TODO: Theme editing button, dan klik je op een theme die er is
        //TODO: Feedback en Theme overview slide list. - Theme overview hoeft maybe niet in een list
        //TODO: Dan krijg je de de difficulty daaronder, en daarna de opdrachten daarvan
        
        _toolbarInt = GUILayout.Toolbar(_toolbarInt, _levelOfDifficulty);

        switch (_toolbarInt)
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
