using UnityEngine;

namespace ScriptableObjects
{
    public class SO_Theme : ScriptableObject
    {
        [Header("Text")]
        public string header;
        [TextArea] public string footer;
    }
}
