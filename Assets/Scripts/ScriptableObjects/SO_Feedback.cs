using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Feedback", menuName = "ScriptableObjects/Slides/Feedback")]
    public class SO_Feedback : ScriptableObject
    {
        [Header("Text")]
        public string header;
        [TextArea] public string footer;
        
        [Header("Time")]
        public int assignmentTime;
        public bool timeIsChangeableByPlayerCount;

        [Header("Images")]
        public Sprite backgroundImage;
        public Sprite headerImage;

        //Next button
    }
}
