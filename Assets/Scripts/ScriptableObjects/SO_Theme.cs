using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObjects/Themes/Theme")]
    public class SO_Theme : ScriptableObject
    {
        [Header("Text")]
        public string header;
        [TextArea] public string footer;
    }
}
