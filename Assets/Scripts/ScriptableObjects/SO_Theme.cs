using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public class SO_Theme : ScriptableObject
    {
        [Header("Text")]
        public string header;
        [TextArea] public string footer;
        
        [HideInInspector] public List<SO_Slide> levelOneSlides = new();
        [HideInInspector] public List<SO_Slide> levelTwoSlides = new();
    }
}
