using ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SO_Theme))]
public class SOThemeButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (SO_Theme)target;

        if (GUILayout.Button("Apply Changes"))
        {
            var themePath = AssetDatabase.GetAssetPath(script);
            var folderPath = $"Assets/Resources/Slides/{script.name}";
            
            script.name = script.header;
            AssetDatabase.RenameAsset(themePath, script.header);

            AssetDatabase.RenameAsset(folderPath, script.name);
        }
    }
}