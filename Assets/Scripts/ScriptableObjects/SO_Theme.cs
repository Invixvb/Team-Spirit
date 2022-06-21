using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public class SO_Theme : ScriptableObject
    {
        [Header("Info Text")]
        public string header;
        [TextArea] public string footer;
        
        public List<SO_Slide> levelOneSlides = new();
        public List<SO_Slide> levelTwoSlides = new();
    }
}
