using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Test")]
    public class SO_Slide : ScriptableObject
    {
        [HideInInspector] public int level;
        
        [HideInInspector] public int themeListIndex;
        
        public enum SlideType { ThemeOverview, Info, Feedback };
        
        [Header("Slide Type")]
        public SlideType slideType;
        
        [Header("Text")]
        public string header;
        [TextArea] public string footer;
        
        [Header("Time")]
        public int assignmentTime;
        public bool timeIsChangeableByPlayerCount;

        [Header("Images")]
        public Sprite backgroundImage;
        public Sprite headerImage;

        [Header("Audio fragment")]
        public AudioClip audioFragment;

        //Opdracht lineup
        //Next Button
    }
}
