using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Theme Overview", menuName = "ScriptableObjects/Slides/Theme Overview")]
    public class SO_ThemeOverview : ScriptableObject
    {
        [Header("Text")]
        public string header;
        [TextArea] public string footer;

        [Header("Image")]
        public Sprite backgroundImage;

        //Opdracht lineup
        //Next Button
    }
}
