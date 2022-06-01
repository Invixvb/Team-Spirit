using UnityEngine;

namespace ScriptableObjects
{
    public class SO_Info : ScriptableObject
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

        [Header("Audio fragment")]
        public AudioClip audioFragment;

        public enum LevelOfDifficultyEnum { Beginner, Advanced }
        
        [Header("Level of Difficulty")]
        public LevelOfDifficultyEnum levelOfDifficulty;

        //Next button
    }
}
